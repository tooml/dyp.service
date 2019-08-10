
using dyp.messagehandling;
using System.Collections.Generic;
using static dyp.contracts.messages.queries.tournament.TournamentQueryResult.Enums;

namespace dyp.contracts.messages.queries.tournament
{
    public class TournamentQueryResult : QueryResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Round> Rounds { get; set; }

        public class Round
        {
            public string Name { get; set; }
            public Fixture[] Matches { get; set; }
        }

        public class Fixture
        {
            public string Id { get; set; }
            public string Home { get; set; }
            public string Away { get; set; }
            public bool Tied { get; set; }
            public int SetsToWin { get; set; }
            public int MaxSetsToPlay { get; set; }
            public IEnumerable<Set> Sets { get; set; }
        }

        public class Set
        {
            public ResultStatus result { get; set; }
        }

        public class Enums
        {
            public enum ResultStatus
            {
                None,
                Home_wins,
                Away_wins,
                Tied
            };
        }     
    }
}
