using System;
using System.Collections.Generic;

namespace dyp.data
{
    public class Match
    {
        public Guid Id { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }
        public int Sets_to_win { get; set; }
        public int Max_sets_to_play { get; set; }
        public List<Set> Sets { get; set; }
    }
}
