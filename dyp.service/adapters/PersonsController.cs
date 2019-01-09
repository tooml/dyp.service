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
        public PersonResponseDto[] Load_persons()
        {
            Console.WriteLine("load persons");
            return _personsRequestHandler().Load_persons();
        }

        [EntryPoint(HttpMethods.Post, "/api/v1/persons")]
        public PersonResponseDto Create_person([Payload] CreatePersonRequestDto request)
        {
            Console.WriteLine("create person");
            return _personsRequestHandler().Create_person(request);
        }

        [EntryPoint(HttpMethods.Put, "/api/v1/persons")]
        public PersonResponseDto Update_person([Payload] UpdatePersonRequestDto request)
        {
            Console.WriteLine("update person");
            return _personsRequestHandler().Update_person(request);
        }
    }
}
