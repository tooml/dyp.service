using dyp.contracts.messages.commands.storeperson;
using dyp.dyp.events;
using dyp.messagehandling;
using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using Newtonsoft.Json;
using nblackbox.contract;

namespace dyp.dyp.messagepipelines.commands.storepersoncommand
{
    public class StorePersonCommandProcessor : IMessageProcessor
    {
        public Output Process(IMessage input, IMessageContext model)
        {
            var cmd = input as StorePersonCommand;
            var data = JsonConvert.SerializeObject(cmd);

            var persont_stored_event = new PersonStored("PersonStored", cmd.Id.ToString(), data);
            return new CommandOutput(new Success(), new Event[] { persont_stored_event });
        }
    }
}
