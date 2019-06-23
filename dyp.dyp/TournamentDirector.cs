using dyp.adapter;
using dyp.contracts;
using dyp.data;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp
{
    public class TournamentDirector
    {
        private readonly IIdProvider _id_provider;

        public TournamentDirector(IIdProvider id_provider)
        {
            _id_provider = id_provider;
        }

        public Round New_round(IEnumerable<Competitor> competitors, Options options, int rounds_played)
        {
            var fixture_generator = new FixtureGenerator(_id_provider);
            var matches = fixture_generator.Start_fixture_generation(competitors, options);

            var round = new Round
            {
                Id = _id_provider.Get_new_id(),
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
