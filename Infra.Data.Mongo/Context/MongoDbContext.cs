using Modelo.Domain.Models;
using MongoDB.Driver;

namespace Infra.Data.Mongo.Context
{
    public class MongoDbContext
    {
        //public static string ConnectionString { get; set; }
        //public static string DatabaseName { get; set; }
        //public static bool IsSSL { get; set; }
        public IMongoDatabase Database { get; }
        public MongoDbContext()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://mongodb-mongo.172.16.70.17.nip.io/:27017"));
            if (true)
            {
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            }
            var mongoClient = new MongoClient(settings);
            Database = mongoClient.GetDatabase("Modelo");
        }
        public IMongoCollection<Funcionario> Funcionarios
        {
            get
            {
                return Database.GetCollection<Funcionario>("Funcionarios");
            }
        }
    }
}
