using servicehost.contract;
using System;
using System.Reflection;

namespace dyp.service.adapters
{
    [Service]
    public class ApiController
    {
        [EntryPoint(HttpMethods.Get, "/api/v1/version")]
        public VersionDto Version()
        {
            var versionDto = new VersionDto
            {
                Timestamp = DateTime.Now,
                Number = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                DbPath = Config.DbPath
            };

            Console.WriteLine($"Api Version: Timestamp: { versionDto.Timestamp }, Number: {versionDto.Number}");
            return versionDto;
        }

        public class VersionDto
        {
            public DateTime Timestamp;
            public string Number;
            public string DbPath;
        }
    }
}
