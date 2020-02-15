using dyp.contracts.messages.commands.createnewround;
using dyp.dyp.events;
using dyp.dyp.events.context;
using dyp.dyp.events.data;
using dyp.messagehandling;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.messagecontext.messagehandling.pipeline.messagecontext;
using dyp.provider.eventstore;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp.messagepipelines.commands.createroundcommand
{
    public class CreateRoundCommandContextManager : IMessageContextManager
    {
        private CreateRoundCommandContextModel _model;
        private readonly IEventStore _es;

        public CreateRoundCommandContextManager(IEventStore es)
        {
            _es = es;
        }

        public IMessageContext Load(IMessage input)
        {
            var cmd = input as CreateRoundCommand;

            _model = new CreateRoundCommandContextModel();
            _model.Players = new List<CreateRoundCommandContextModel.Player>();
            _model.Walkover_player_ids = new List<string>();         

            var events = _es.Replay(new TournamentContext(cmd.Tournament_id, nameof(TournamentContext)), 
                typeof(RoundCreated), typeof(PlayersStored), 
                typeof(OptionsCreated), typeof(WalkoverPlayed));

            Update(events);

            return _model;
        }

        public void Update(IEnumerable<Event> events)
           => events.ToList().ForEach(ev => Apply(ev));

        private void Apply(Event ev)
        {
            switch(ev)
            {
                case PlayersStored ps:
                    var player_data = ev.Data as PlayerData;
                    _model.Players.Add(new CreateRoundCommandContextModel.Player()
                    {
                        Id = player_data.Player.Id,
                        First_name = player_data.Player.First_name,
                        Last_name = player_data.Player.Last_name
                    });
                    break;

                case OptionsCreated os:
                    var options_data = ev.Data as OptionsData;
                    _model.Tables = options_data.Tables;
                    _model.Sets = options_data.Sets;
                    _model.Drawn = options_data.Drawn;
                    _model.Walkover = options_data.Walkover;
                    break;

                case WalkoverPlayed wp:
                    var walkover_data = ev.Data as WalkoverData;
                    _model.Walkover_player_ids.Add(walkover_data.Id);
                    break;

                case RoundCreated rc:
                    _model.Round_count++;
                    break;
            }
        }
    }
}