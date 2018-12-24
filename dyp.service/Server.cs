using dyp.contracts;
using dyp.service.adapters;
using System;

namespace dyp.service
{
    public class Server
    {
        public Server(IPersonsRequestHandler personsHandler)
        {
            PersonsController._personsRequestHandler = () => personsHandler;
        }

        public void Run(Uri address)
        {
            servicehost.ServiceHost.Run(address, new[] { typeof(ApiController), typeof(PersonsController) });
        }
    }
}
