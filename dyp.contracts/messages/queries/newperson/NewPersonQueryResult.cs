using System;

namespace dyp.contracts.messages.queries.newperson
{
    public class NewPersonQueryResult : QueryResult
    {
        public Guid Id;
        public string FirstName;
        public string LastName;
    }
}
