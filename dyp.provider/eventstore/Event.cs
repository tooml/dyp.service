using System;

namespace dyp.provider.eventstore
{
    public abstract class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public DateTime Timestamp { get; set; }
        public string Data { get; set; }

        public Event(string name, string context, string data)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Context = context;
            Timestamp = DateTime.Now;
            Data = data;
        }
    }
}
