using SeparateDMAndPMWithTracking.Contracts;
using SeparateDMAndPMWithTracking.Domain.PublisherAgg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeparateDMAndPMWithTracking.Persistence.Entities
{
    [Table("SocialAccount")]
    public class SocialAccountEntity : IEntityModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public AccountType AccountType { get; set; }

        public virtual ICollection<PublisherAccountEnitity> PublisherAccounts { get; set; }
    }
}
