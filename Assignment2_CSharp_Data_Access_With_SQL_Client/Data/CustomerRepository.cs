using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Assignment2_CSharp_Data_Access_With_SQL_Client
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Get the Connection String
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-S7M0NAJ\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }

        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
                    "VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        success = command.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return success;
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                List<Customer> custList = new List<Customer>();
                string sql = "SELECT * FROM Customer";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                temp.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                temp.Country = reader.IsDBNull(7) ? null : reader.GetString(7);
                                temp.PostalCode = reader.IsDBNull(8) ? null : reader.GetString(8);
                                temp.Phone = reader.IsDBNull(9) ? null : reader.GetString(9);
                                temp.Email = reader.IsDBNull(11) ? null : reader.GetString(11);
                                custList.Add(temp);

                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return custList;
            }
        }

        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                Customer customer = new Customer();
                string sql = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                customer.Country = reader.IsDBNull(7) ? null : reader.GetString(7);
                                customer.PostalCode = reader.IsDBNull(8) ? null : reader.GetString(8);
                                customer.Phone = reader.IsDBNull(9) ? null : reader.GetString(9);
                                customer.Email = reader.IsDBNull(11) ? null : reader.GetString(11);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return customer;
            }
        }

        /// <summary>
        /// Get customer by name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public List<Customer> GetCustomerByName(string firstName)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                List<Customer> custList = new List<Customer>();
                string sql = "SELECT * FROM Customer WHERE FirstName LIKE @FirstName";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                temp.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                temp.Country = reader.IsDBNull(7) ? null : reader.GetString(7);
                                temp.PostalCode = reader.IsDBNull(8) ? null : reader.GetString(8);
                                temp.Phone = reader.IsDBNull(9) ? null : reader.GetString(9);
                                temp.Email = reader.IsDBNull(11) ? null : reader.GetString(11);
                                custList.Add(temp);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return custList;
            }
        }

        /// <summary>
        /// Get amount of customers in country
        /// </summary>
        /// <returns></returns>
        public List<CustomersInCountry> GetCustomersInCountry()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                List<CustomersInCountry> custList = new List<CustomersInCountry>();
                List<int> testlist = new List<int>();

                string sql = "SELECT Country, count(Country) FROM Customer GROUP by Country ORDER BY 2 DESC";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomersInCountry temp = new CustomersInCountry();
                                
                                temp.Country = reader.IsDBNull(0) ? null : reader.GetString(0);
                                temp.CountryCount = reader.GetInt32(1);
                                custList.Add(temp);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                foreach (var item in testlist)
                {
                    Console.WriteLine(item);
                }

                return custList;
            }
        }

        /// <summary>
        /// Get customer with highest spending
        /// </summary>
        /// <returns></returns>
        public List<CustomerHighestSpender> GetHighestSpenders()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                List<CustomerHighestSpender> custList = new List<CustomerHighestSpender>();
                string sql = "SELECT Customer.CustomerId, Customer.FirstName, Customer.LastName, SUM(Invoice.Total) FROM Customer INNER JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId GROUP BY Customer.CustomerId, Customer.FirstName, Customer.LastName ORDER BY SUM(Invoice.Total) DESC";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerHighestSpender temp = new CustomerHighestSpender();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                temp.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                temp.TotalSum = reader.GetDecimal(3);
                                custList.Add(temp);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return custList;
            }
        }

        /// <summary>
        /// Get most popular genre for a selected customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CustomerGenre> GetPopularGenre(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                List<CustomerGenre> custList = new List<CustomerGenre>();
                string sql = "WITH GenrePopularity AS" +
                    "(SELECT COUNT(Genre.Name) AS Popularity, Customer.CustomerId, Customer.FirstName, Customer.LastName, Genre.Name " +
                    "FROM ((((Customer " +
                    "INNER JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId) " +
                    "INNER JOIN InvoiceLine ON Invoice.InvoiceId = InvoiceLine.InvoiceId) " +
                    "INNER JOIN Track ON InvoiceLine.TrackId = Track.TrackId) " +
                    "INNER JOIN Genre ON Track.GenreId = Genre.GenreId) WHERE Customer.CustomerId = @CustomerId GROUP BY Customer.CustomerId, Customer.FirstName, Customer.LastName, Genre.Name) " +
                    "SELECT gp.CustomerId, gp.FirstName, gp.LastName, gp.Name, gp.Popularity " +
                    "FROM GenrePopularity gp " +
                    "WHERE gp.Popularity = (SELECT max(Popularity) FROM GenrePopularity)";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerGenre temp = new CustomerGenre();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                temp.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                temp.FavoriteGenre = reader.IsDBNull(3) ? null : reader.GetString(3);
                                temp.GenreCount = reader.GetInt32(4);
                                custList.Add(temp);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return custList;
            }
        }

        /// <summary>
        /// Get a subset of customers
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Customer> GetSubsetCustomers(int offset, int limit)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                List<Customer> custList = new List<Customer>();
                string sql = "SELECT * FROM Customer ORDER BY CustomerId " +
                    "OFFSET @offset ROWS " +
                    "FETCH NEXT @limit ROWS ONLY";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@offset", offset);
                        command.Parameters.AddWithValue("@limit", limit);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                temp.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                temp.Country = reader.IsDBNull(7) ? null : reader.GetString(7);
                                temp.PostalCode = reader.IsDBNull(8) ? null : reader.GetString(8);
                                temp.Phone = reader.IsDBNull(9) ? null : reader.GetString(9);
                                temp.Email = reader.IsDBNull(11) ? null : reader.GetString(11);
                                custList.Add(temp);

                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return custList;
            }
        }

        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Console.WriteLine("Done. \n");

                string sql = "UPDATE Customer SET FirstName = @FirstName WHERE CustomerId = @CustomerId";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        success = command.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return success;
        }
    }
}
