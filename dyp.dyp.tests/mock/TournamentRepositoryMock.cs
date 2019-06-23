using dyp.contracts;
using dyp.data;
using System;
using System.Collections.Generic;

namespace dyp.dyp.tests.mock
{
    public class TournamentRepositoryMock : ITournamentRepository
    {
        public IEnumerable<Tournament> Load()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tournament> Load(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public void Save(Tournament tournament)
        {
            
        }
    }
}
