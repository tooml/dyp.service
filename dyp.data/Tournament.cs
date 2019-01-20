using System;
using System.Collections.Generic;

namespace dyp.data
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Options Options { get; set; }
        public List<Competitor> Competitors { get; set; }
        public List<Round> Rounds { get; set; }
    }
}
