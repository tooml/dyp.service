using dyp.adapter;
using dyp.contracts;
using dyp.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp
{
    public class FixtureGenerator
    {
        private const int COMPETITORS_PER_FIXTURE = 4;
        private readonly IIdProvider _id_provider;

        public FixtureGenerator(IIdProvider id_provider)
        {
            _id_provider = id_provider;
        }

        public IEnumerable<Fixture> Start_fixture_generation(IEnumerable<Competitor> competitors, Options options)
        {
            var fixtures_count = Calculate_fixtures_count(competitors);
            var competitors_count_in_round = Competitors_count_in_round(fixtures_count);
            var orderd_competitors = Order_competitors(competitors).ToList();

            var competitors_in_round = Split_competitors_from_walkover(orderd_competitors, competitors_count_in_round);
            Mark_walkover_competitors(orderd_competitors, competitors_count_in_round);

            var teams = Draw_teams(options, competitors_in_round);
            return Draw_fixtures(options, teams);
        }

        private int Calculate_fixtures_count(IEnumerable<Competitor> competitors)
        {
            return competitors.Count() / COMPETITORS_PER_FIXTURE;
        }

        private int Competitors_count_in_round(int fixtures)
        {
            return fixtures * COMPETITORS_PER_FIXTURE;
        }

        private IEnumerable<Competitor> Order_competitors(IEnumerable<Competitor> competitors)
        {
            return competitors.OrderByDescending(competitor => competitor.Walkover_count);
        }

        private IEnumerable<Competitor> Split_competitors_from_walkover(IEnumerable<Competitor> competitors, int competitors_count)
        {
            return competitors.Take(competitors_count).ToList();
        }

        private void Mark_walkover_competitors(IEnumerable<Competitor> competitors, int competitors_count)
        {
            var walkover_competitors = competitors.Skip(competitors_count).ToList();

            foreach (var competitor in walkover_competitors)
                competitor.Walkover_count++;
        }

        private IEnumerable<Team> Draw_teams(Options options, IEnumerable<Competitor> competitors)
        {
            var team_builder = Determine_team_building_strategy(options);
            return team_builder.Determine_teams(competitors);
        }

        private SimpleTeamBuilder Determine_team_building_strategy(Options options)
        {
            switch (options.Fair_lots)
            {
                case true:
                    throw new NotImplementedException();
                case false:
                    return new SimpleTeamBuilder();
                default:
                    throw new NotSupportedException();
            }
        }

        private IEnumerable<Fixture> Draw_fixtures(Options options, IEnumerable<Team> teams)
        {
            var shuffled_teams = ListShuffle.Shuffle_list(teams.ToArray());
            var pairs = ListPairing.Pairing_list(shuffled_teams);
            var max_sets_to_win = Calculate_max_sets_to_play(options.Sets, options.Tied);
            var fixtures = Build_fixtures(pairs, options.Sets, max_sets_to_win).ToList();

            return fixtures;
        }

        private int Calculate_max_sets_to_play(int sets_to_win, bool tied)
        {
            if (tied)
                return sets_to_win;

            return sets_to_win + (sets_to_win - 1);
        }

        private IEnumerable<Fixture> Build_fixtures(IEnumerable<Tuple<Team, Team>> team_pairs, int sets_to_win, int max_sets_to_play)
        {
            return team_pairs.Select(pair =>
                                            new Fixture()
                                            {
                                                Id = _id_provider.Get_new_id(),
                                                Home = pair.Item1,
                                                Away = pair.Item2,
                                                Sets_to_win = sets_to_win,
                                                Max_sets_to_play = max_sets_to_play
                                            });
        }
    }
}
