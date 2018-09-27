using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using OnlineBookShop.Contracts.Models.Data;
using OnlineBookShop.Data.Interfaces;

namespace OnlineBookShop.Data.Repos
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {

        public Customer AddCustomer(Customer details)
        {
            //
            string sqlCustomerInsert = 
                "INSERT INTO Customers (Name,Surname,Email,Address) Values (@Name,@Surname,@Email,@Address);";
                
            // Add the parameters to use in the insert query
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Name", details.Name, DbType.String, ParameterDirection.Input);
            parameter.Add("@Surname", details.Surname, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", details.Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Address", details.Address, DbType.String, ParameterDirection.Input);

            //using (var connection = new SqlConnection(ConnectionStringHelper.GetConnectionString("")))
            using(var connection = Connection)
            {
                connection.Execute(sqlCustomerInsert,
                                    parameter,
                                    commandType: CommandType.Text);

                var newCustomer = connection.QueryFirstOrDefault<Customer>("", new { Id = 1 });
            }
               

            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer details)
        {
            //
            string sqlCustomerUpdate =
                "UPDATE Customers SET Name = @Name, Surname = @Surname, Email = @Email, Address = @Address WHERE Id = @CustomerId;";

            // Add the parameters to use in the update query.
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CustomerId", details.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Name", details.Name, DbType.String, ParameterDirection.Input);
            parameter.Add("@Surname", details.Surname, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", details.Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Address", details.Address, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(ConnectionStringHelper.GetConnectionString("")))
            {
                var affectedRows = connection.Execute(sqlCustomerUpdate,
                    parameter,
                    commandType: CommandType.Text);

            }
            throw new NotImplementedException();
        }
    }
}
