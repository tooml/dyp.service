using dyp.adapter;
using dyp.data;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp
{
    public class TournamentDirector
    {
        public Round New_round(IEnumerable<Competitor> competitors, Options options, int rounds_played)
        {
            var fixture_generator = new FixtureGenerator();
            var matches = fixture_generator.Start_fixture_generation(competitors, options);

            var round = new Round
            {
                Id = IdGenerator.Deliver_id(),
                Name = Round_name(rounds_played),
                Matches = matches.ToList()
            };

            return round;
        }

        private string Round_name(int rounds_played)
        {
            return string.Concat("Runde ", rounds_played + 1);
        }
    }
}
