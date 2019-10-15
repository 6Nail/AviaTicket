using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace AviaTiket
{
    public class AviaRepository : UserRepositorys
    {
        private const string connectionString = "Server=A-305-08;Database=AviaTicket;Trusted_Connection=True;";
        private readonly DbProviderFactory providerFactory;
        public AviaRepository(string provider)
        { 
            providerFactory = DbProviderFactories.GetFactory(provider);
        }
        public void Add(Passenger passenger)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand sqlCommand = connection.CreateCommand())
            {
                //string query = $"insert into Passenger (id, Name, ToFly, TimeExit,Registr) values(@Id, " +
                //        $"@Name, " +
                //        $"@ToFly," +
                //        $"@TimeExit," +
                //        $"@Registr);";

                //sqlCommand.CommandText = query;

                DbParameter parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.Guid;
                parameter.ParameterName = "@Id";
                parameter.Value = passenger.Id;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@Name";
                parameter.Value = passenger.Name;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.DateTime;
                parameter.ParameterName = "@ToFly";
                parameter.Value = passenger.ToFly;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.DateTime;
                parameter.ParameterName = "@TimeExit";
                parameter.Value = passenger.TimeExit;
                sqlCommand.Parameters.Add(parameter);


                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.Boolean;
                parameter.ParameterName = "@Registr";
                parameter.Value = passenger.Registr;
                sqlCommand.Parameters.Add(parameter);
                connection.ConnectionString = connectionString;
                connection.Open();

                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        sqlCommand.Transaction = transaction;
                        sqlCommand.ExecuteNonQuery();
                        // И так далее тоже самое с другими командами
                        transaction.Commit();
                    }
                    catch (SqlException exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public void Delete(Guid IdPassenger)
        {
            throw new NotImplementedException();
        }

        public ICollection<Passenger> GetAll()
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand sqlCommand = connection.CreateCommand())
            {
                string queryPass = "select * from Passenger;";
                //string queryTicket = "select * from Ticket;";
                //string queryFlight = "select * from Flight;";
                //string queryReg = "select * from Registration;";

                sqlCommand.CommandText = queryPass;
                //sqlCommand.CommandText = queryTicket;
                //sqlCommand.CommandText = queryFlight;
               // sqlCommand.CommandText = queryReg;


                connection.Open();
                DbDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Passenger> categories = new List<Passenger>();
                while (sqlDataReader.Read())
                {
                    categories.Add(new Passenger
                    {
                        Id = Guid.Parse(sqlDataReader["id"].ToString()),
                        Name = sqlDataReader["name"].ToString(),
                        ToFly = sqlDataReader["ToFly"].ToString(),
                        TimeExit = DateTime.Parse(sqlDataReader["TimeExit"].ToString()),
                        Registr = bool.Parse(sqlDataReader["ToFly"].ToString())


                    });
                }
                return categories;
            }
        }

        public void Update(Passenger passenger)
        {

        }
    }
}
