using dyp.messagehandling;

namespace dyp.contracts.messages.commands.createtournament
{
    public class CreateTournamentCommand : Command
    {
        public string Name;
        public int Tables;
        public int Sets;
        public int Points;
        public int Points_drawn;
        public bool Drawn;
        public bool Walkover;
        public string[] Competitors_ids;
    }
}
