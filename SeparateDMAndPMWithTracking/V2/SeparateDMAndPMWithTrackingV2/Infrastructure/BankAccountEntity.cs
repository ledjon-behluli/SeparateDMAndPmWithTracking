using SeparateDMAndPMWithTrackingV2.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeparateDMAndPMWithTrackingV2.Infrastructure
{
    [Table("BankAccount")]
    public class BankAccountEntity : IBankAccountState
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Balance { get; set; }
        public bool Frozen { get; set; }

        [MaxLength(100)]
        public string Reason { get; set; }

        public DateTime? ChangedOn { get; set; }

        public object Clone()
        {
            return new BankAccountEntity()
            {
                Id = Id,
                Name = Name,
                Balance = Balance,
                Frozen = Frozen,
                Reason = Reason,
                ChangedOn = ChangedOn
            };
        }
    }
}
