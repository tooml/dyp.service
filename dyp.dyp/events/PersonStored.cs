using nblackbox.contract;

namespace dyp.dyp.events
{
    public class PersonStored : Event
    {
        public PersonStored(string name, string context, string data) : base(name, context, data) { }
    }
}
