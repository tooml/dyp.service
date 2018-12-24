using dyp.contracts;
using dyp.contracts.dto;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class PersonsController
    {
        public static Func<IPersonsRequestHandler> _personsRequestHandler;

        [EntryPoint(HttpMethods.Get, "/api/v1/persons")]
        public PersonsResponseDto Load_persons()
        {
            Console.WriteLine("load persons");
            return _personsRequestHandler().Load_persons();
        }

        [EntryPoint(HttpMethods.Get, "/api/v1/persons/{personId}")]
        public string Load_person(string personId)
        {
            Console.WriteLine($"load person with id: { personId }");
            return _personsRequestHandler().Load_person(new Guid());
        }
    }
}
