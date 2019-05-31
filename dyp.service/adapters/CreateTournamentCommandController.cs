using dyp.contracts.messages;
using dyp.contracts.messages.commands.createtournament;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class CreateTournamentCommandController
    {
        public static Func<ICreateTournamentCommandHandling> _createTournamentCommandHandling;

        [EntryPoint(HttpMethods.Post, "/api/v1/turnier")]
        public CommandStatus Create_turnier([Payload] CreateTournamentCommand createTournamentCommand)
        {
            Console.WriteLine("create new turnier");
            return null;
            //return _managementRequestHandler().Create_tournament(request);
        }
    }
}
