using System;

namespace dyp.data
{
    public class Competitor
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public int Walkover_count { get; set; }
    }
}
