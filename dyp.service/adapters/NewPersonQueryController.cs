using dyp.contracts.messages.queries.newperson;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class NewPersonQueryController
    {
        public static Func<INewPersonQueryHandling> _newPersonQueryHandler;

        [EntryPoint(HttpMethods.Get, "/api/v1/person")]
        public NewPersonQueryResult New_person()
        {
            Console.WriteLine("new person");
            var result = _newPersonQueryHandler().Handle(new NewPersonQuery());
            return result;
        }
    }
}
