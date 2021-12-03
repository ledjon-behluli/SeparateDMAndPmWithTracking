using System;

namespace SeparateDMAndPMWithTrackingV2.Domain
{
    public interface IBankAccountState : ICloneable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool Frozen { get; set; }
        public string Reason { get; set; }
        public DateTime? ChangedOn { get; set; }
    }
}
