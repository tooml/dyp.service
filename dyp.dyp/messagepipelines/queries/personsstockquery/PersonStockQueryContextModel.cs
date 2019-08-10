using dyp.messagehandling.pipeline.messagecontext;
using System.Collections.Generic;

namespace dyp.dyp.messagepipelines.queries.personsstockquery
{
    public class PersonStockQueryContextModel : IMessageContext
    {
        public class PersonInfo
        {
            public string Id;
            public string FirstName;
            public string LastName;
            public int TurnierParticipations;
            public int Games;
            public int Wins;
            public int Looses;
        }

        public IEnumerable<PersonInfo> Persons;
    }
}
