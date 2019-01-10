using System;
using System.Collections.Generic;
using static dyp.data.Enums;

namespace dyp.data
{
    public class Fixture
    {
        public Guid Id { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }
        public List<Set> Sets { get; set; }
        public ResultStatus Fixture_status { get; set; } = ResultStatus.None;
    }
}
