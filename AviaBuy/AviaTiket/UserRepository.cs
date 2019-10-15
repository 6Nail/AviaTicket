using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace AviaTiket
{
    public class UserRepository 
    {
        private readonly DbConnection connection;
        private readonly DbProviderFactory providerFactory;
        public UserRepository(DbConnection connection)
        {
            this.connection = connection;

        }

    } 
}
