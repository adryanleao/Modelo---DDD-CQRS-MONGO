using Modelo.Domain.Models;
using MongoDB.Driver;
using System;

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
           // MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://mongodb-mongo.172.16.70.17.nip.io"));
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(Environment.GetEnvironmentVariable("DefaultConnectionMongo")));
            if (true)
            {
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            }
            var mongoClient = new MongoClient(settings);
            var teste = settings.ToString();
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


//using Modelo.Domain.Models;
//using MongoDB.Driver;
//using System;

//namespace Infra.Data.Mongo.Context
//{
//    public class MongoDbContext
//    {
//        //public static string ConnectionString { get; set; }
//        //public static string DatabaseName { get; set; }
//        //public static bool IsSSL { get; set; }
//        public IMongoDatabase Database { get; }
//        public MongoDbContext()
//        {
//            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://ModeloUser:$enha123@mongodb-mongo.172.16.70.17.nip.io,mongodb-mongo.172.16.70.17.nip.io,mongodb-mongo.172.16.70.17.nip.io/admin?ssl=true&authSource=admin"));
//           //  MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
//          //  settings.Credential = MongoCredential.CreateCredential("test", "ModeloUser", "$enha123");
//           // settings.UseSsl = true;
//           // settings.VerifySslCertificate = false;
//            settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
//            var mongoClient = new MongoClient(settings);
//            Database = mongoClient.GetDatabase("test");
//            //MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://mongodb:27017"));
//            //// MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
//            //settings.Credential = MongoCredential.CreateCredential(Environment.GetEnvironmentVariable("MongoDataBase"), Environment.GetEnvironmentVariable("MongoUser"), Environment.GetEnvironmentVariable("MongoPassword"));
//            //settings.UseSsl = true;
//            //settings.VerifySslCertificate = false;
//            //settings.SslSettings = new SslSettings(){ EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
//            //var mongoClient = new MongoClient(settings);
//            //Database = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("MongoDataBase"));
//        }

//    }
//}