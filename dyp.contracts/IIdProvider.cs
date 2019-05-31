using System;

namespace dyp.contracts
{
    public interface IIdProvider
    {
        Guid Get_new_id();
    }
}
