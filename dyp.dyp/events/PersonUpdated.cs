using dyp.provider.eventstore;

namespace dyp.dyp.events
{
    public class PersonUpdated : Event
    {
        public PersonUpdated(string name, string context, string data) : base(name, context, data) { }
    }
}
