using System;
using System.Collections.Generic;

namespace dyp.data
{
    public class Round
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
    }
}
