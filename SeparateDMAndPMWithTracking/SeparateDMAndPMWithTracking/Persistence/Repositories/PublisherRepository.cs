using Microsoft.EntityFrameworkCore;
using SeparateDMAndPMWithTracking.Contracts;
using SeparateDMAndPMWithTracking.Domain.Common;
using SeparateDMAndPMWithTracking.Domain.PublisherAgg;
using SeparateDMAndPMWithTracking.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeparateDMAndPMWithTracking.Persistence.Repositories
{
    public class PublisherRepository : ModelsMapper<Publisher, PublisherEntity>,
                                       IPublisherRepository
    {
        public PublisherRepository()
        {

        }

        public Publisher GetById(PublisherId id)
        {
            using (var context = new ApplicationContext())
            {
                var entity = LoadWithNoTracking(context, id);
                return GetDomainResult(entity);
            }
        }

        public void Update(Publisher publisher)
        {
            using (var context = new ApplicationContext())
            {
                var publisherEntity = LoadWithNoTracking(context, publisher.Id);

                if (publisherEntity != null)
                {
                    publisherEntity = ToEntityModel(publisher);

                    context.Reconcile(publisherEntity, c =>
                    {
                        c.WithMany(o => o.PublisherAccounts, co => 
                            co.WithOne(o => o.SocialAccount));
                    });

                    context.SaveChanges();
                }
            }
        }

        private PublisherEntity LoadWithNoTracking(ApplicationContext context, PublisherId id)
        {
            var entity = context.Publisher
                .AsNoTracking()
                .Include(p => p.PublisherAccounts)
                .ThenInclude(pa => pa.SocialAccount)
                .FirstOrDefault(p => p.Id == id.Value);

            return entity;         
        }

        protected override Publisher ToDomainModel(PublisherEntity entityModel)
        {
            var socialAccounts = new List<SocialAccount>();

            foreach (var accountPM in entityModel.PublisherAccounts.Select(pa => pa.SocialAccount))
                socialAccounts.Add(new SocialAccount(
                    id: new SocialAccountId(accountPM.Id),
                    email: accountPM.Email,
                    type: accountPM.AccountType
                ));

            return entityModel == null ? null :
                new Publisher(
                id: new PublisherId(entityModel.Id),
                name: entityModel.Name,
                assignedSocialAccounts: socialAccounts
            );
        }

        protected override PublisherEntity ToEntityModel(Publisher domainModel)
        {
            var socialAccounts = new List<SocialAccountEntity>();
            var publisherAccounts = new List<PublisherAccountEnitity>();

            var publisher = new PublisherEntity()
            {
                Id = domainModel.Id.Value,
                Name = domainModel.Name
            };

            foreach (var socialAccountDM in domainModel.AssignedSocialAccounts)
            {
                var sa = new SocialAccountEntity()
                {
                    Id = socialAccountDM.Id.Value,
                    Email = socialAccountDM.Email,
                    AccountType = socialAccountDM.AccountType
                };

                socialAccounts.Add(sa);

                publisherAccounts.Add(new PublisherAccountEnitity()
                {
                    PublisherId = domainModel.Id.Value,
                    Publisher = publisher,
                    SocialAccountId = socialAccountDM.Id.Value,
                    SocialAccount = sa
                });
            }

            publisher.PublisherAccounts = publisherAccounts;

            return domainModel == null ? null : publisher;
        }      
    }
}
