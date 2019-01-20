
namespace dyp.contracts.dto
{
    public class CreateTournamentRequestDto
    {
        public string Name { get; set; }
        public string[] Competitors { get; set; }
        public int Tables { get; set; }
        public int Sets { get; set; }
        public int Points { get; set; }
        public int PointsTied { get; set; }
        public bool Tied { get; set; }
        public bool Walkover { get; set; }
        public bool FairLots { get; set; }
    }
}
