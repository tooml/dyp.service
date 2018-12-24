using appcfg;
using System;

namespace dyp.service.adapters
{
    public static class Config
    {
        public static void Load(string[] args)
        {
            var schema = new AppCfgSchema(
                "dyp.service.config.json",
                new Route("run", "start", isDefault: true)
                    .Param("address", "a", ValueTypes.String, "DYPAPP_SERVICE_ADDRESS", defaultValue: "http://localhost:9000")
                    .Param("dbpath", "db", ValueTypes.String, "DYPAPP_SERVICE_DATABASEPATH", defaultValue: ".")
            );

            var comp = new AppCfgCompiler(schema);
            var cfg = comp.Compile(args);

            Address = new Uri(cfg.address);
            DbPath = cfg.dbpath;
        }

        public static Uri Address { get; private set; }
        public static string DbPath { get; private set; }
    }
}
