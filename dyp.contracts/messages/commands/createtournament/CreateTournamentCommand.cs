
namespace dyp.contracts.messages.commands.createtournament
{
    public class CreateTournamentCommand : Command
    {
        public string Name;
        public int Tables;
        public int Sets;
        public int Points;
        public bool PointsTied;
        public bool Tied;
        public bool Walkover;
        public bool FairLots;
        public string[] competitorsIds;
    }
}
