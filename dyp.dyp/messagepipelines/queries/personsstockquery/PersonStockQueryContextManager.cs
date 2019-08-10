using dyp.dyp.events;
using dyp.messagehandling;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.messagecontext.messagehandling.pipeline.messagecontext;
using nblackbox.contract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp.messagepipelines.queries.personsstockquery
{
    public class PersonStockQueryContextManager : IMessageContextManager
    {
        private readonly List<PersonStockQueryContextModel.PersonInfo> _persons;

        public PersonStockQueryContextManager(IBlackBox es)
        {
            _persons = new List<PersonStockQueryContextModel.PersonInfo>();
            Update(es.Player.ForEvent(typeof(PersonStored).Name).Play());
        }

        public IMessageContext Load(IMessage _) => new PersonStockQueryContextModel { Persons = _persons };

        public void Update(IEnumerable<IRecordedEvent> events)
        {
            events.ToList().ForEach(ev =>
            {
                var person = JsonConvert.DeserializeObject<PersonStockQueryContextModel.PersonInfo>(ev.Data);
                _persons.Add(person);
            });
        }
    }
}
