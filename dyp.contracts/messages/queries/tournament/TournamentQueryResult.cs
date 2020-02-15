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
            public Match[] Matches { get; set; }
        }

        public class Match
        {
            public string Id { get; set; }
            public string Home { get; set; }
            public string Away { get; set; }
            public bool Tied { get; set; }
            public int Sets_to_win { get; set; }
            public int Max_sets_to_play { get; set; }
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
