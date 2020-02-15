using dyp.contracts.messages.commands.storeperson;
using dyp.dyp.messagepipelines.commands.storepersoncommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;
using System.Net;

namespace dyp.service.adapters
{
    [Service]
    public class StorePersonCommandController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/person")]
        public HttpStatusCode Store_person([Payload] StorePersonCommand store_person_command)
        {
            Console.WriteLine($"store person id: { store_person_command.Id }");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new StorePersonCommandContextManager(_es);
                var message_processor = new StorePersonCommandProcessor();
                msgpump.Register<StorePersonCommand>(context_manager, message_processor);

                var result = msgpump.Handle(store_person_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
