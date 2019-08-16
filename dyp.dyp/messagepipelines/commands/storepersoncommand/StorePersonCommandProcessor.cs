using dyp.contracts.messages.commands.storeperson;
using dyp.dyp.events;
using dyp.messagehandling;
using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using dyp.provider.eventstore;
using Newtonsoft.Json;

namespace dyp.dyp.messagepipelines.commands.storepersoncommand
{
    public class StorePersonCommandProcessor : IMessageProcessor
    {
        public Output Process(IMessage input, IMessageContext model)
        {
            var cmd = input as StorePersonCommand;
            var cmdModel = model as StorePersonCommandContextModel;

            var ev = Map(cmdModel, cmd);
            return new CommandOutput(new Success(), new Event[] { ev });
            //return new CommandOutput(new Failure("error Father"));
        }

        private Event Map(StorePersonCommandContextModel cmdModel, StorePersonCommand cmd)
        {
            var data = JsonConvert.SerializeObject(cmd);

            if (cmdModel.Person_existing)
                return new PersonUpdated("PersonUpdated", cmd.Id.ToString(), data);

            return new PersonStored("PersonStored", cmd.Id.ToString(), data);
        }
    }
}
