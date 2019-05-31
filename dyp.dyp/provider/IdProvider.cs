using dyp.contracts;
using System;

namespace dyp.dyp.provider
{
    public class IdProvider : IIdProvider
    {
        public Guid Get_new_id()
        {
            return Guid.NewGuid();
        }
    }
}