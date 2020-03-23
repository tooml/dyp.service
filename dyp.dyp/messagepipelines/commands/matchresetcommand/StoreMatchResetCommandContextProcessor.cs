using dyp.dyp.events;
using dyp.dyp.events.context;
using dyp.dyp.events.data;
using dyp.messagehandling;
using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using dyp.provider.eventstore;

namespace dyp.dyp.messagepipelines.commands.matchresetcommand
{
    public class StoreMatchResetCommandContextProcessor : IMessageProcessor
    {
        public Output Process(IMessage input, IMessageContext model)
        {
            var ctx_model = model as StoreMatchResetCommandContextModel;
            var ev = Map(ctx_model);

            return new CommandOutput(new Success(), new Event[] { ev });
        }

        private Event Map(StoreMatchResetCommandContextModel ctx_model)
        {
            var match_reset_data = new MatchResetData()
            {
                Tournament_id = ctx_model.Tournament_id,
                Match_id = ctx_model.Match_id
            };

            return new MatchReseted(nameof(MatchReseted),
                new TournamentContext(ctx_model.Tournament_id, nameof(TournamentContext)), match_reset_data);
        }
    }
}