﻿using dyp.provider.eventstore;

namespace dyp.dyp.events.data
{
    public class PlayersStored : Event
    {
        public PlayersStored(string name, EventContext context, EventData data) : base(name, context, data) { }
    }
}
