using SeparateDMAndPMWithTracking.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeparateDMAndPMWithTracking.Persistence.Entities
{
    /// <summary>
    /// Many-to-Many relationship 
    /// </summary>
    [Table("PublisherAccount")]
    public class PublisherAccountEnitity : IEntityModel
    {
        public Guid PublisherId { get; set; }
        public PublisherEntity Publisher { get; set; }

        public Guid SocialAccountId { get; set; }
        public SocialAccountEntity SocialAccount { get; set; }
    }
}
