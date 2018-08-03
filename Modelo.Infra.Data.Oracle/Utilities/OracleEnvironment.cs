using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Modelo.Infra.Data.Oracle.Utilities
{
    public static class OracleEnvironment
    {
        public static IConfiguration Config { get; }

        static OracleEnvironment()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: true)
                .AddJsonFile("config.test.json", optional: true)
                .AddEnvironmentVariables();

            Config = configBuilder.Build()
                .GetSection("Test:Oracle");
        }

        private const string DefaultConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=True;Connect Timeout=30";

        public static string DefaultConnection => Config["DefaultConnection"] ?? DefaultConnectionString;

        public static bool IsTeamCity => Environment.GetEnvironmentVariable("TEAMCITY_VERSION") != null;

        public static string ElasticPoolName => Config["ElasticPoolName"];

        public static bool? GetFlag(string key)
        {
            bool flag;
            return bool.TryParse(Config[key], out flag) ? flag : (bool?)null;
        }

        public static int? GetInt(string key)
        {
            int value;
            return int.TryParse("5", out value) ? value : (int?)null;
        }
    }
}
