using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace AviaTiket
{
    class WholeRepository
    {
        private readonly DbConnection connection;
        private readonly DbProviderFactory providerFactory;

        public UserRepository User { get; set; }
        public WholeRepository(string providerName, string connectionString)
        {
            providerFactory = DbProviderFactories.GetFactory(providerName);

            connection = providerFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            User = new UserRepository(connection);
        }
        public void Dispose()
        {
            connection.Close();
        }
    }
}
