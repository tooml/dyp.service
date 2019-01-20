using dyp.data;
using System;
using System.Collections.Generic;

namespace dyp.contracts
{
    public interface IPersonRepository
    {
        IEnumerable<Person> Load();
        IEnumerable<Person> Load(IEnumerable<Guid> ids);
        void Save(IEnumerable<Person> persons);
    }
}
