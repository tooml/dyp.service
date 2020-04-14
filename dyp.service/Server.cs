﻿using dyp.provider.eventstore;
using dyp.service.adapters;
using System;

namespace dyp.service
{
    public class Server
    {
        public Server()
        {
            var event_store = new EventStore(@"C:/test_bb");

            PersonStockQueryController._es = event_store;
            StorePersonCommandController._es = event_store;
            DeletePersonCommandController._es = event_store;
            CompetitorsQueryController._es = event_store;
            CreateTournamentCommandController._es = event_store;
            TournamentDeleteCommandController._es = event_store;
            TournamentStockQueryController._es = event_store;
            TournamentQueryController._es = event_store;
            CreateRoundCommandController._es = event_store;
            MatchResultNotificationController._es = event_store;
            TournamentRoundQueryController._es = event_store;
            MatchResetCommandController._es = event_store;
            TournamentRankingQueryController._es = event_store;
            TournamentCompetitorsQueryController._es = event_store;
            ChangePlayersCommandController._es = event_store;
            ChangeTournamentOptionsComandController._es = event_store;
        }

        public void Run(Uri address)
        {
            servicehost.ServiceHost.Run(address, new[] 
            {
                typeof(ApiController),
                typeof(PersonStockQueryController),
                typeof(DeletePersonCommandController),
                typeof(CompetitorsQueryController),
                typeof(PersonTemplateQueryController),
                typeof(StorePersonCommandController),
                typeof(CreateTournamentCommandController),
                typeof(TournamentDeleteCommandController),
                typeof(TournamentStockQueryController),
                typeof(TournamentQueryController),
                typeof(CreateRoundCommandController),
                typeof(MatchResultNotificationController),
                typeof(TournamentRoundQueryController),
                typeof(MatchResetCommandController),
                typeof(TournamentRankingQueryController),
                typeof(TournamentCompetitorsQueryController),
                typeof(ChangePlayersCommandController),
                typeof(ChangeTournamentOptionsComandController)
            });
        }
    }
}
