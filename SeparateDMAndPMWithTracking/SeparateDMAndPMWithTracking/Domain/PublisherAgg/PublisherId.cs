using SeparateDMAndPMWithTracking.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeparateDMAndPMWithTracking.Domain.PublisherAgg
{
    public class PublisherId : TypedIdValueBase
    {
        public PublisherId(Guid value) : base(value)
        {
        }
    }
}
