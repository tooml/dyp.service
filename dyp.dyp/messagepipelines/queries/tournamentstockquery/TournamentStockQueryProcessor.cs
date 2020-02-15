using dyp.contracts.messages.queries.tournamentstock;
using dyp.messagehandling;
using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using System.Linq;
using static dyp.contracts.messages.queries.tournamentstock.TournamentStockQueryResult;

namespace dyp.dyp.messagepipelines.queries.tournamentstockquery
{
    public class TournamentStockQueryProcessor : IMessageProcessor
    {
        public Output Process(IMessage input, IMessageContext model)
        {
            var queryModel = model as TournamentStockQueryContextModel;
            return new QueryOutput(new TournamentStockQueryResult
            {
                Tournaments = queryModel.Tournaments.Select(t => Map(t))
                                                    .OrderByDescending(t => t.Created).ToList()
            });
        }

        private Tournament Map(TournamentStockQueryContextModel.Tournament t)
        {
            return new Tournament() { Id = t.Id, Name = t.Name, Created = t.Created };
        }
    }
}
