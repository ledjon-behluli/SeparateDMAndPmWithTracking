using System;
using System.Collections.Generic;
using System.Text;

namespace SeparateDMAndPMWithTracking.Domain.PublisherAgg
{
    public interface IPublisherRepository
    {
        Publisher GetById(PublisherId id);
        void Update(Publisher publisher);
    }
}
