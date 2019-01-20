
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
    }
}
