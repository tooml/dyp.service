using nblackbox.contract;
using System.Collections.Generic;

namespace dyp.messagehandling.pipeline.messagecontext
{
    public interface IMessageContextBuilder
    {
        void Update(IEnumerable<IRecordedEvent> events);
    }
}
