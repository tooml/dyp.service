using dyp.dyp.events;
using dyp.messagehandling;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.messagecontext.messagehandling.pipeline.messagecontext;
using dyp.provider.eventstore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp.messagepipelines.queries.personsstockquery
{
    public class PersonStockQueryContextManager : IMessageContextManager
    {
        private readonly List<PersonStockQueryContextModel.PersonInfo> _persons;

        public PersonStockQueryContextManager(IEventStore es)
        {
            _persons = new List<PersonStockQueryContextModel.PersonInfo>();
            Update(es.Replay(typeof(PersonStored), typeof(PersonUpdated)));
        }

        public IMessageContext Load(IMessage _) => new PersonStockQueryContextModel { Persons = _persons };

        public void Update(IEnumerable<Event> events)
            => events.ToList().ForEach(ev => Apply(ev));

        private void Apply(Event ev)
        {
            var person = JsonConvert.DeserializeObject<PersonStockQueryContextModel.PersonInfo>(ev.Data);

            switch (ev)
            {
                case PersonStored ps:
                    _persons.Add(person);
                    break;
                case PersonUpdated pu:
                    var update = _persons.Single(pers => pers.Id.Equals(person.Id));
                    update.FirstName = person.FirstName;
                    update.LastName = person.LastName;
                    break;
            }
        }
    }
}
