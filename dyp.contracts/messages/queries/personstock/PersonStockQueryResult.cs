using dyp.messagehandling;
using System;

namespace dyp.contracts.messages.queries.personstock
{
    public class PersonStockQueryResult : QueryResult
    {
        public class Person
        {
            public string Id;
            public string FirstName;
            public string LastName;
        }

        public Person[] Persons;
    }
}
