using dyp.messagehandling;

namespace dyp.contracts.messages.queries.personstock
{
    public class PersonStockQueryResult : QueryResult
    {
        public class Person
        {
            public string Id;
            public string First_name;
            public string Last_name;
        }

        public Person[] Persons;
    }
}
