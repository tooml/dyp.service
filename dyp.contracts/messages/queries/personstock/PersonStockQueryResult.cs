
using System;

namespace dyp.contracts.messages.queries.personstock
{
    public class PersonStockQueryResult : QueryResult
    {
        public class Person
        {
            public Guid Id;
            public string FirstName;
            public string LastName;
            public int TurnierParticipations;
            public int Games;
            public int Wins;
            public int Looses;
        }

        public Person[] Persons;
    }
}
