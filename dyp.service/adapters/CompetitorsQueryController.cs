using dyp.contracts.messages.queries.competitors;
using dyp.dyp.messagepipelines.queries.competitorsquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class CompetitorsQueryController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Get, "/api/v1/competitors")]
        public CompetitorsQueryResult Get_competitors()
        {
            Console.WriteLine("competitors query");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new CompetitorsQueryContextManager(_es);
                var message_processor = new CompetitorsQueryProcessor();
                msgpump.Register<CompetitorsQuery>(context_manager, message_processor);

                var result = msgpump.Handle(new CompetitorsQuery()) as CompetitorsQueryResult;
                return result;
            }
        }
    }
}
