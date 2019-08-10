using dyp.messagehandling;

namespace dyp.contracts.messages.queries.persontemplate
{
    public class PersonTemplateQueryResult : QueryResult
    {
        public string Id;
        public string FirstName;
        public string LastName;
        public int TurnierParticipations;
        public int Games;
        public int Wins;
        public int Looses;
    }
}
