using dyp.contracts;
using dyp.contracts.dto;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class TournamentManagementController
    {
        public static Func<ITournamentManagementRequestHandler> _managementRequestHandler;

        [EntryPoint(HttpMethods.Post, "/api/v1/persons")]
        public TournamentCreatedResponseDto Create_turnier([Payload] CreateTournamentRequestDto request)
        {
            Console.WriteLine("create new turnier");
            return _managementRequestHandler().Create_tournament(request);
        }
    }
}
