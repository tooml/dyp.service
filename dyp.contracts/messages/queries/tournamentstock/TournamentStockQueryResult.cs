using dyp.messagehandling;
using System;
using System.Collections.Generic;

namespace dyp.contracts.messages.queries.tournamentstock
{
    public class TournamentStockQueryResult : QueryResult
    {
        public class TournamentInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public DateTime Created { get; set; }
        }    

        public List<TournamentInfo> TournamentInfos { get; set; }
    }
}
