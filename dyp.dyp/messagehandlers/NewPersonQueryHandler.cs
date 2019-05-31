using dyp.contracts;
using dyp.contracts.messages.queries.newperson;

namespace dyp.dyp.messagehandlers
{
    public class NewPersonQueryHandler : INewPersonQueryHandling
    {
        private IIdProvider _id_provider;

        public NewPersonQueryHandler(IIdProvider id_provider)
        {
            _id_provider = id_provider;
        }

        public NewPersonQueryResult Handle(NewPersonQuery request)
        {
            var id = _id_provider.Get_new_id();
            return new NewPersonQueryResult
            {
                Id = id,
                FirstName = string.Empty,
                LastName = string.Empty
            };
        }
    }
}
