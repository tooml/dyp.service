using dyp.contracts;
using dyp.contracts.dto;
using dyp.contracts.messages.queries.personstock;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class PersonStockQueryController
    {
        public static Func<IPersonStockQueryHandling> _personStockQueryHandler;

        [EntryPoint(HttpMethods.Get, "/api/v1/persons")]
        public PersonStockQueryResult Load_persons()
        {
            Console.WriteLine("load persons");
            return _personStockQueryHandler().Handle(new PersonStockQuery());
        }
    }
}
