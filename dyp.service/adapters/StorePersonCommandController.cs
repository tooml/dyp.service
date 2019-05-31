using dyp.contracts.messages;
using dyp.contracts.messages.commands.storeperson;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class StorePersonCommandController
    {
        public static Func<IStorePersonCommandHandling> _storePersonCommandHandler;

        [EntryPoint(HttpMethods.Post, "/api/v1/person")]
        public CommandStatus New_person([Payload] StorePersonCommand storePersonCommand)
        {
            Console.WriteLine($"store person id: { storePersonCommand.Id }");
            return _storePersonCommandHandler().Handle(storePersonCommand);
        }
    }
}
