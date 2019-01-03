using System;
using System.Collections.Generic;

namespace dyp.adapter.tests
{
    public static class IdGeneratorMock
    {
        public static IEnumerable<Guid> Deliver_id()
        {
            yield return new Guid("6f38ee76-6481-465d-a097-c23ae8b364da");
            yield return new Guid("99113cc4-adc6-4459-bb67-164185bd6515");
            yield return new Guid("bfd864af-37cf-41c4-84a2-bf4f604b24d5");
        }
    }
}
