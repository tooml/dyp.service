using dyp.contracts.data;
using System.Collections.Generic;

namespace dyp.dyp.domain
{
    public class TournamentDirector
    {
        public TournamentDirector() { }

        public Round New_round(IEnumerable<Player> players, int rounds_played)
        {
            var match_generator = new MatchGenerator();
            var matchList = match_generator.Start_match_generation(players);

            var round = new Round
            {
                Name = Round_name(rounds_played),
                Matches = matchList.Matches,
                Walkover = matchList.Walkover
            };

            return round;
        }

        private string Round_name(int rounds_played)
        {
            return string.Concat("Runde ", rounds_played + 1);
        }
    }
}
