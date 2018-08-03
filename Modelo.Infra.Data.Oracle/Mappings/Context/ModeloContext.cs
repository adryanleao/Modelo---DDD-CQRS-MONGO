using Modelo.Domain.Models;
using Modelo.Infra.Data.Oracle.Mappings;
using System;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Modelo.Infra.Data.Oracle.Utilities;

namespace Modelo.Infra.Data.Oracle.Context
{
    public class ModeloContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            // define the database to use
            var connectionStringBuilder = new OracleConnectionStringBuilder
                {
                    DataSource = "//exa02-scan-cassi:1521/SOCTSTBD001",
                    UserID = "usrpoc",
                    Password = "teste123"
                }.ConnectionString;

            //var _oracleConnection = new OracleConnection
            //{
            //    ConnectionString = connectionStringBuilder
            //};
            //_oracleConnection.Open();

            //_oracleConnection.Close();

            optionsBuilder.UseOracle(connectionStringBuilder)
            .UseInternalServiceProvider(_serviceProvider);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
