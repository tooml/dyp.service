using dyp.contracts.messages.queries.tournament;
using dyp.dyp.messagepipelines.mapping;
using dyp.messagehandling;
using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using System.Linq;

namespace dyp.dyp.messagepipelines.queries.tournamentquery
{
    public class TournamentQueryProcessor : IMessageProcessor
    {
        public Output Process(IMessage input, IMessageContext model)
        {
            var ctx_model = model as TournamentQueryContextModel;

            var tournament = Map(ctx_model);
            return new QueryOutput(new TournamentQueryResult { Tournament = tournament });
        }

        private contracts.messages.queries.data.Tournament Map(TournamentQueryContextModel ctx_model)
        {
            return new contracts.messages.queries.data.Tournament()
            {
                Id = ctx_model.Id,
                Name = ctx_model.Name,
                Created = ctx_model.Created,
                Rounds = ctx_model.Rounds.Select(r => TournamentMapper.Map(r, ctx_model.Id))
            };
        }
    }
}
