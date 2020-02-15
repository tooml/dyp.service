using dyp.messagehandling;
using System.Collections.Generic;

namespace dyp.contracts.messages.queries.tournamentstock
{
    public class TournamentStockQueryResult : QueryResult
    {
        public class Tournament
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Created { get; set; }
        }    

        public List<Tournament> Tournaments { get; set; }
    }
}
