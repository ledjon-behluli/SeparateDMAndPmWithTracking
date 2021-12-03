using SeparateDMAndPMWithTracking.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeparateDMAndPMWithTracking.Domain.PublisherAgg
{
    public class SocialAccountId : TypedIdValueBase
    {
        public SocialAccountId(Guid value) : base(value)
        {
        }
    }
}
