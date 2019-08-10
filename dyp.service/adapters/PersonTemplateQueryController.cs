using dyp.contracts.messages.queries.persontemplate;
using dyp.dyp.messagepipelines.queries.persontemplatequery;
using dyp.dyp.provider;
using dyp.messagehandling;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class PersonTemplateQueryController
    {
        [EntryPoint(HttpMethods.Get, "/api/v1/person/template")]
        public PersonTemplateQueryResult Get_person_template()
        {
            Console.WriteLine("person template query");

            using (var msgpump = new MessagePump())
            {
                var id_provider = new IdProvider();

                var context_manager = new PersonTemplateQueryContextManager();
                var message_processor = new PersonTemplateQueryProcessor(id_provider);
                msgpump.Register<PersonTemplateQuery>(context_manager, message_processor);

                var result = msgpump.Handle(new PersonTemplateQuery()) as PersonTemplateQueryResult;
                return result;
            }
        }
    }
}
