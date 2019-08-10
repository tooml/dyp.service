using dyp.contracts.messages;
using dyp.contracts.messages.commands.storeperson;
using dyp.dyp.messagepipelines.commands.storepersoncommand;
using dyp.messagehandling;
using nblackbox.contract;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class StorePersonCommandController
    {
        public static IBlackBox _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/person")]
        public CommandStatus Store_person([Payload] StorePersonCommand storePersonCommand)
        {
            Console.WriteLine($"store person id: { storePersonCommand.Id }");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new StorePersonCommandContextManager();
                var message_processor = new StorePersonCommandProcessor();
                msgpump.Register<StorePersonCommand>(context_manager, message_processor);

                var result = msgpump.Handle(storePersonCommand);
                return null;
            }
        }
    }
}
