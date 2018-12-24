using dyp.service.adapters;
using System;

namespace dyp.service
{
    public class Server
    {
        public Server()
        {

        }

        public void Run(Uri address)
        {
            servicehost.ServiceHost.Run(address, new[] { typeof(ApiController) });
        }
    }
}
