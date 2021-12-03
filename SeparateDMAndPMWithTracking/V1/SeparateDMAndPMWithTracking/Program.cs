using SeparateDMAndPMWithTracking.Domain.PublisherAgg;
using SeparateDMAndPMWithTracking.Persistence.Repositories;
using System;
using System.Linq;

namespace SeparateDMAndPMWithTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            PublisherId id = new PublisherId(Guid.Parse("6679C0E9-1C2C-4F99-9EB1-ED892225176B"));       // John

            PublisherRepository repository = new PublisherRepository();
            var publisher = repository.GetById(id);

            var account = publisher.AssignedSocialAccounts.FirstOrDefault(asa => asa.Email == "juile@microsoft.us");

            publisher.ChangePublisherName("Derick");
            publisher.ChangeAccountEmail(account, "juile@netflix.io");

            repository.Update(publisher);

            Console.ReadKey();
        }
    }
}
