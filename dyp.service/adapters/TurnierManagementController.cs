using servicehost.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dyp.service.adapters
{
    [Service]
    public class TurnierManagementController
    {
        [EntryPoint(HttpMethods.Post, "/api/v1/persons")]
        public void Create_turnier([Payload] string request)
        {
            Console.WriteLine("create new turnier");
            
        }
    }
}
