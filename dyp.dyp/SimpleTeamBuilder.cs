using dyp.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp
{
    public class SimpleTeamBuilder
    {
        public IEnumerable<Team> Determine_teams(IEnumerable<Competitor> competitors)
        {
            var shuffled_competitors = ListShuffle.Shuffle_list(competitors.ToArray());
            var pairs = ListPairing.Pairing_list(shuffled_competitors);

            return Build_teams(pairs);
        }

        private IEnumerable<Team> Build_teams(IEnumerable<Tuple<Competitor, Competitor>> competitior_pairs)
        {
            return competitior_pairs.Select(pair => 
                                            new Team() { Member_one = pair.Item1, Member_two = pair.Item2 });
        }
    }
}
