using dyp.contracts.data;
using dyp.contracts.messages.commands.createnewround;
using dyp.dyp.domain;
using dyp.dyp.events;
using dyp.dyp.events.context;
using dyp.dyp.events.data;
using dyp.messagehandling;
using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using dyp.provider.eventstore;
using System.Collections.Generic;
using System.Linq;
using static dyp.dyp.messagepipelines.commands.createroundcommand.CreateRoundCommandContextModel;

namespace dyp.dyp.messagepipelines.commands.createroundcommand
{
    public class CreateRoundCommandProcessor : IMessageProcessor
    {
        public Output Process(IMessage input, IMessageContext model)
        {
            var cmd = input as CreateRoundCommand;
            var cmd_model = model as CreateRoundCommandContextModel;

            var tournament_director = new TournamentDirector();
            var round = tournament_director.New_round(Map(cmd_model).ToList(), cmd_model.Round_count);

            return new CommandOutput(null, new Event[] { });
        }

        private IEnumerable<contracts.data.Player> Map(CreateRoundCommandContextModel model)
        {
            return model.Players.Select(pl => new contracts.data.Player()
            {
                Id = pl.Id,
                First_name = pl.First_name,
                Last_name = pl.Last_name,
                Walkover_played = model.Walkover_player_ids.Count(p => p == pl.Id)
            });
        }

        private Event Map(Round round)
        {
            RoundData round_data = new RoundData()
            {
                Id = null,
                Name = round.Name
            };

            return new RoundCreated(nameof(RoundCreated), 
                new TournamentContext(null, nameof(TournamentContext)), round_data);
        }

        private IEnumerable<Event> Map(IEnumerable<contracts.data.Match> matches, MatchOptions match_options)
        {
            var matches_data = matches.Select(w => new MatchData()
            {
                Id = null,
                Home = new MatchData.Team()
                {
                    Player_one = new events.data.Player()
                    {
                        Id = w.Home.Member_one.Id,
                        First_name = w.Home.Member_one.First_name,
                        Last_name = w.Home.Member_one.Last_name
                    },
                    Player_two = new events.data.Player()
                    {
                        Id = w.Home.Member_two.Id,
                        First_name = w.Home.Member_two.First_name,
                        Last_name = w.Home.Member_two.Last_name
                    }
                },
                Away = new MatchData.Team()
                {
                    Player_one = new events.data.Player()
                    {
                        Id = w.Away.Member_one.Id,
                        First_name = w.Away.Member_one.First_name,
                        Last_name = w.Away.Member_one.Last_name
                    },
                    Player_two = new events.data.Player()
                    {
                        Id = w.Away.Member_two.Id,
                        First_name = w.Away.Member_two.First_name,
                        Last_name = w.Away.Member_two.Last_name
                    }
                },
                Sets = match_options.Sets,
                Drawn = match_options.Drawn,
            }).ToList();


            return matches_data.Select(f =>
            {
                return new MatchCreated(nameof(MatchCreated), 
                    new TournamentContext(null, nameof(TournamentContext)), f);
            }).ToList();
        }

        private IEnumerable<Event> Map(IEnumerable<contracts.data.Player> walkover)
        {
            var walkover_datas = walkover.Select(w => new WalkoverData() { Id = w.Id }).ToList();
            return walkover_datas.Select(w =>
            {
                return new WalkoverPlayed(nameof(WalkoverPlayed), 
                    new TournamentContext(null, nameof(TournamentContext)), w);
            }).ToList();
        }
    }
}
