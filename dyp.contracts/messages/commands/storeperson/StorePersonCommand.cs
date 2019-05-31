using System;

namespace dyp.contracts.messages.commands.storeperson
{
    public class StorePersonCommand : Command
    {
        public Guid Id;
        public string FirstName;
        public string LastName;
    }
}
