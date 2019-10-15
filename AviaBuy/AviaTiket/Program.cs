using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace AviaTiket
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();
            var providerName = configurationRoot.GetSection("AppConfig").GetChildren().Single(item => item.Key == "ProviderName").Value;
            var connectionString = configurationRoot.GetConnectionString("ConnectionString");


            DbProviderFactories.RegisterFactory(providerName, SqlClientFactory.Instance);

            Passenger passenger = new Passenger()
            {
                Name = "Akchurin Nail",
                ToFly = "Dubai",
                TimeExit = DateTime.Now,
                Registr = true,
                
            };

           

            //repository.GetAll();
        }
    }
}
