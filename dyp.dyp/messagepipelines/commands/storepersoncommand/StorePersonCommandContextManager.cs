using dyp.messagehandling;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.messagecontext.messagehandling.pipeline.messagecontext;
using nblackbox.contract;
using System;
using System.Collections.Generic;

namespace dyp.dyp.messagepipelines.commands.storepersoncommand
{
    public class StorePersonCommandContextManager : IMessageContextManager
    {
        public IMessageContext Load(IMessage input) => new StorePersonCommandContextModel();

        public void Update(IEnumerable<IRecordedEvent> events) { }
    }
}
