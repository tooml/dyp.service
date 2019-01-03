using System;

namespace dyp.adapter
{
    public static class IdGenerator
    {
        public static Guid Deliver_id()
        {
            return Guid.NewGuid();
        }
    }
}
