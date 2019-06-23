using dyp.data;
using System;
using System.Collections.Generic;

namespace dyp.contracts
{
    public interface ITournamentRepository
    {
        void Save(Tournament tournament);
        IEnumerable<Tournament> Load();
        IEnumerable<Tournament> Load(IEnumerable<Guid> ids);
    }
}
