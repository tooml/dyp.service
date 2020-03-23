using dyp.contracts.messages.commands.matchresult;
using dyp.dyp.events;
using dyp.dyp.events.context;
using dyp.dyp.events.data;
using dyp.messagehandling;
using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using dyp.provider.eventstore;
using System.Linq;

namespace dyp.dyp.messagepipelines.commands.matchresultcommand
{
    public class StoreMatchResultCommandProcessor : IMessageProcessor
    {
        public Output Process(IMessage input, IMessageContext model)
        {
            var cmd = input as MatchResultNotificationCommand;
            var ctx_model = model as StoreMatchResultCommandContextModel;
            var ev = Map(ctx_model, cmd);

            return new CommandOutput(new Success(), new Event[] { ev });
        }

        private Event Map(StoreMatchResultCommandContextModel cmd_model, MatchResultNotificationCommand cmd)
        {
            var match_result_data = new MatchResultData()
            {
                Match_id = cmd.MatchId,
                Results = cmd.Results.Select(result => (events.data.SetResult)result).ToList()
            };

            return new MatchPlayed(nameof(MatchPlayed),
                new TournamentContext(cmd_model.Tournament_id, nameof(TournamentContext)), match_result_data);
        }
    }
}
