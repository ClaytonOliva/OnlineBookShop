﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using OnlineBookShop.Contracts.Models.Data;
using OnlineBookShop.Data.Interfaces;

namespace OnlineBookShop.Data.Repos
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="details">Customer details to add.</param>
        /// <returns>Customer Data object.</returns>
        public Customer AddCustomer(Customer details)
        {
            //
            string sqlCustomerInsert = 
                "INSERT INTO Customers (Name,Surname,Email,Address) Values (@Name,@Surname,@Email,@Address);" +
                "SELECT LAST_INSERT_ID();";
                
            // Add the parameters to use in the insert query
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Name", details.Name, DbType.String, ParameterDirection.Input);
            parameter.Add("@Surname", details.Surname, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", details.Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Address", details.Address, DbType.String, ParameterDirection.Input);

            using(var connection = new MySqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                var newInsertedId =
                    connection.Query<int>(sqlCustomerInsert, parameter).Single();

                return this.GetCustomer(newInsertedId);
            }
        }

        /// <summary>
        /// Deletes the customer by ID.
        /// </summary>
        /// <param name="id">The Id of the customer to deelte.</param>
        /// <returns>Successful delete or not.</returns>
        public bool DeleteCustomer(int Id)
        {
            //
            string sqlCustomerDelete =
                "DELETE FROM Customers WHERE Id = @Id;";

            using (var connection = new MySqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                var rowsAffected =
                    connection.Execute(sqlCustomerDelete, new { Id });

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Gets the customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>Customer Data object.</returns>
        public Customer GetCustomer(int Id)
        {
            var sqlCustomerSelect =
                "SELECT Id, Name, Surname, Email, Address FROM Customers WHERE Id = @Id;";

            using (var db = new MySqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                return db.Query<Customer>(sqlCustomerSelect, new { Id }).SingleOrDefault();
            }
        }

        /// <summary>
        /// Updates the details of the Customer.
        /// </summary>
        /// <param name="details">Customer details to update.</param>
        /// <returns>Customer Data object.</returns>
        public Customer UpdateCustomer(Customer details)
        {
            //
            var sqlCustomerUpdate =
                "UPDATE Customers SET Name = @Name, Surname = @Surname, Email = @Email, Address = @Address WHERE Id = @CustomerId;";

            // Add the parameters to use in the update query.
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CustomerId", details.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Name", details.Name, DbType.String, ParameterDirection.Input);
            parameter.Add("@Surname", details.Surname, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", details.Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Address", details.Address, DbType.String, ParameterDirection.Input);

            using (var connection = new MySqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                connection.Execute(sqlCustomerUpdate, parameter);

                //
                return this.GetCustomer(details.Id);
            }
        }
    }
}
