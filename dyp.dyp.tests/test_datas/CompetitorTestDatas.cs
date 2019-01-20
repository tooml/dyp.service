using dyp.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp.tests.test_datas
{
    public static class CompetitorTestDatas
    {
        public static IEnumerable<Competitor> Competitors()
        {
            return PersonTestDatas.Persons().Select(person => new Competitor()
            {
                Id = Guid.NewGuid(),
                Person = person,
                Walkover_count = 0
            }).ToList();
        }
    }
}
