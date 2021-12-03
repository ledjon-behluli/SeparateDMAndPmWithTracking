using SeparateDMAndPMWithTracking.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeparateDMAndPMWithTracking.Persistence.Entities
{
    [Table("Publisher")]
    public class PublisherEntity : IEntityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PublisherAccountEnitity> PublisherAccounts { get; set; }
    }
}
