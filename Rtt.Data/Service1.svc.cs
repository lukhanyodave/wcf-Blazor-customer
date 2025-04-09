using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Web.UI;
namespace Rtt.Data
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static string connectionString = "Server=DESKTOP-EL7EHQ2\\SQLEXPRESS;Database=dbEcentric;Trusted_Connection=True;MultipleActiveResultSets=true";
        public void AddCustomer(CustomerContract customer)             
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO Customers (Id,Name, LastName, Gender, ResidentialAddress, WorkAddress, PostalAddress,Cell,WorkNumber ) VALUES (@Id,@Name,@LastName, @Gender, @ResidentialAddress,@WorkAddress,@PostalAddress,@Cell,@WorkNumber )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", customer.Id);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@ResidentialAddress", customer.ResidentialAddress);
                    cmd.Parameters.AddWithValue("@WorkAddress", customer.WorkAddress);
                    cmd.Parameters.AddWithValue("@PostalAddress", customer.PostalAddress);
                    cmd.Parameters.AddWithValue("@Cell", customer.Cell);
                    cmd.Parameters.AddWithValue("@WorkNumber", customer.WorkNumber);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();   
                }
            }
        }

        public List<CustomerContract> GetAll()
        {
            List<CustomerContract> customers = new List<CustomerContract>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, LastName, Gender, ResidentialAddress, WorkAddress, PostalAddress, Cell, WorkNumber  FROM Customers";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerContract customer = new CustomerContract()
                    {
                        Id = (Guid)reader["Id"],
                        Name = reader["Name"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        ResidentialAddress = reader["ResidentialAddress"].ToString(),
                        WorkAddress = reader["WorkAddress"].ToString(),
                        PostalAddress = reader["PostalAddress"].ToString(),
                        Cell = reader["Cell"].ToString(),
                        WorkNumber = reader["WorkNumber"].ToString()
                    };
                    customers.Add(customer);
                    //Console.WriteLine($"ID: {reader["EmployeeID"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Age: {reader["Age"]}");
                }
                return customers;
            }
        }

        public void UpdateCustomer(CustomerContract customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE Customers SET Name = @Name, LastName = @LastName, Gender = @Gender,ResidentialAddress=@ResidentialAddress,WorkAddress=@WorkAddress,PostalAddress=@PostalAddress WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", customer.Id);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@ResidentialAddress", customer.ResidentialAddress);
                    cmd.Parameters.AddWithValue("@WorkAddress", customer.WorkAddress);
                    cmd.Parameters.AddWithValue("@PostalAddress", customer.PostalAddress);
                    cmd.Parameters.AddWithValue("@Cell", customer.Cell);
                    cmd.Parameters.AddWithValue("@WorkNumber", customer.WorkNumber);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) updated.");
                }
                catch (Exception)
                {
                    throw;
                }
                finally 
                {
                    conn.Close();   
                }
            }
        }

        public CustomerContract GetById(Guid id)
        {

            CustomerContract customer = new CustomerContract();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT Id,Name,LastName,Gender, ResidentialAddress, WorkAddress, PostalAddress, Cell, WorkNumber  FROM Customers WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        customer.Id = (Guid)reader["Id"];
                        customer.Name = reader["Name"].ToString();
                        customer.LastName = reader["LastName"].ToString();
                        customer.Gender = reader["Gender"].ToString();
                        customer.ResidentialAddress = reader["ResidentialAddress"].ToString();
                        customer.WorkAddress = reader["WorkAddress"].ToString();
                        customer.PostalAddress = reader["PostalAddress"].ToString();
                        customer.Cell = reader["Cell"].ToString();
                        customer.WorkNumber = reader["WorkNumber"].ToString();
                    }
                   
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine($"SQL Error: {sqlEx.Message}");
                }
                finally
                {
                    conn.Close();   
                }
            }

            return customer;
        }
    }
}
