using dyp.contracts;
using dyp.contracts.dto;
using System;

namespace dyp.dyp
{
    public class PersonsRequestHandler : IPersonsRequestHandler
    {
        public PersonsResponseDto Load_persons()
        {
            return new PersonsResponseDto() { Persons = new string[] { "Person 1", "Person 2", "Person 3" } };
        }

        public string Load_person(Guid personId)
        {
            return "Person 2";
        }
    }
}
