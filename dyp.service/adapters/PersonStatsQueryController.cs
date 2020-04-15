using dyp.contracts.messages.queries.personstats;
using dyp.dyp.messagepipelines.queries.personstatsquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class PersonStatsQueryController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Get, "/api/v1/person/stats")]
        public PersonStatsQueryResult Load_persons_stats(string personId)
        {
            Console.WriteLine($"person stats query: { personId }");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new PersonStatsQueryContextManager(_es);
                var message_processor = new PersonStatsQueryProcessor();
                msgpump.Register<PersonStatsQuery>(context_manager, message_processor);

                var result = msgpump.Handle(new PersonStatsQuery() { PersonId = personId }) as PersonStatsQueryResult;
                return result;
            }
        }
    }
}