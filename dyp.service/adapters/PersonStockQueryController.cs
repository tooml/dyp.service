using dyp.contracts.messages.queries.personstock;
using dyp.dyp.messagepipelines.queries.personsstockquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class PersonStockQueryController
    {
        //public static Func<IPersonStockQueryHandling> _personStockQueryHandler;

        public static IEventStore _es;

        //public PersonStockQueryController(string test)
        //{
        //    Console.WriteLine(test);
        //}

        [EntryPoint(HttpMethods.Get, "/api/v1/person/all")]
        public PersonStockQueryResult Load_persons()
        {
            Console.WriteLine("person stock query");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new PersonStockQueryContextManager(_es);
                var message_processor = new PersonStockQueryProcessor();
                msgpump.Register<PersonStockQuery>(context_manager, message_processor);
            
                var result = msgpump.Handle(new PersonStockQuery()) as PersonStockQueryResult;
                return result;
            }
        }
    }
}
