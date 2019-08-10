using dyp.contracts.messages.queries.personstock;
using dyp.messagehandling;
using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using System.Linq;
using static dyp.contracts.messages.queries.personstock.PersonStockQueryResult;

namespace dyp.dyp.messagepipelines.queries.personsstockquery
{
    public class PersonStockQueryProcessor : IMessageProcessor
    {
        public Output Process(IMessage input, IMessageContext model)
        {
            var queryModel = model as PersonStockQueryContextModel;
            return new QueryOutput(new PersonStockQueryResult { Persons = 
                                                                    queryModel.Persons.Select(p => 
                                                                                    Map(p)).ToArray() });
        }

        private Person Map(PersonStockQueryContextModel.PersonInfo personInfo)
        {
            return new Person()
            {
                Id = personInfo.Id,
                FirstName = personInfo.FirstName,
                LastName = personInfo.LastName
            };
        }
    }
}
