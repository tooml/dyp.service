
using System.Collections.Generic;
using static dyp.contracts.dto.Enums;

namespace dyp.contracts.dto
{
    public class TournamentCreatedResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public RoundResponseDto Round {get; set;}
    }

    public class RoundResponseDto
    {
        public string Name { get; set; }
        public FixtureResponseDto[] Matches { get; set; }
    }

    public class FixtureResponseDto
    {
        public string Id { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public bool Tied { get; set; }
        public int SetsToWin { get; set; }
        public int MaxSetsToPlay { get; set; }
        public IEnumerable<SetsResponseDto> Sets { get; set; }
    }

    public class SetsResponseDto
    {
        public ResultStatus result { get;set; }
    }

    public class Enums
    {
        public enum ResultStatus
        {
            None,
            Home_wins,
            Away_wins,
            Tied
        };
    }
}
