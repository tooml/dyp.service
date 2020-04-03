using dyp.contracts.data;
using System.Collections.Generic;

namespace dyp.dyp.domain
{
    public class TournamentDirector
    {
        public TournamentDirector() { }

        public Round New_round(IEnumerable<Player> players)
        {
            var match_generator = new MatchGenerator();
            var matchList = match_generator.Start_match_generation(players);

            var round = new Round
            {
                Matches = matchList.Matches,
                Walkover = matchList.Walkover
            };

            return round;
        }
    }
}
