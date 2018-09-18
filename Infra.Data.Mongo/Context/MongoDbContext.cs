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
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://mongodb:27017"));
            //  MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
            //  settings.Credential = MongoCredential.CreateCredential("test", "ModeloUser", "$enha123");
            // settings.UseSsl = true;
            // settings.VerifySslCertificate = false;
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            Database = mongoClient.GetDatabase("test");
            //MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://mongodb:27017"));
            //// MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
            //settings.Credential = MongoCredential.CreateCredential(Environment.GetEnvironmentVariable("MongoDataBase"), Environment.GetEnvironmentVariable("MongoUser"), Environment.GetEnvironmentVariable("MongoPassword"));
            ////settings.UseSsl = true;
            ////settings.VerifySslCertificate = false;
            ////settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            //var mongoClient = new MongoClient(settings);
            //Database = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("MongoDataBase"));
        }

    }
}