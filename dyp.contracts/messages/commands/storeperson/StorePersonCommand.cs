using dyp.messagehandling;

namespace dyp.contracts.messages.commands.storeperson
{
    public class StorePersonCommand : Command
    {
        public string Id;
        public string First_name;
        public string Last_name;
    }
}
