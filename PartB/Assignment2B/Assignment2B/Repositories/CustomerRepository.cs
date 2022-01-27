using System;
using System.Collections.Generic;
using Assignment2B.Models;
using Microsoft.Data.SqlClient;

namespace Assignment2B.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        public bool AddNewCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) "
                        + "VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
   
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "SELECT ALL CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Customer temp = new();
                                temp.Id = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                if (reader.IsDBNull(3)) temp.Country = "NULL";
                                else temp.Country = reader.GetString(3);
                                if (reader.IsDBNull(4)) temp.Phone = "NULL";
                                else temp.Phone = reader.GetString(4);
                                if (reader.IsDBNull(5)) temp.Country = "NULL";
                                else temp.Email = reader.GetString(5);
                                customers.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql = $"SELECT ALL CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = '{id}'";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                if (reader.IsDBNull(3)) customer.Country = "NULL";
                                else customer.Country = reader.GetString(3);
                                if (reader.IsDBNull(4)) customer.Phone = "NULL";
                                else customer.Phone = reader.GetString(4);
                                if (reader.IsDBNull(5)) customer.Country = "NULL";
                                else customer.Email = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
        public Customer GetCustomer(string name)
        {
            Customer customer = new();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql = $"SELECT ALL CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE '{name}' OR LastName LIKE '{name}';";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                if (reader.IsDBNull(3)) customer.Country = "NULL";
                                else customer.Country = reader.GetString(3);
                                if (reader.IsDBNull(4)) customer.Phone = "NULL";
                                else customer.Phone = reader.GetString(4);
                                if (reader.IsDBNull(5)) customer.Country = "NULL";
                                else customer.Email = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public List<Customer> GetPageOfCustomers(int pageLength, int skip)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql =
                        $"SELECT ALL CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                        $"FROM Customer " +
                        $"ORDER BY CustomerId ASC " +
                        $"OFFSET @skip ROWS " +
                        $"FETCH NEXT @pageLength ROWS ONLY;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@pageLength", pageLength);
                        command.Parameters.AddWithValue("@skip", skip);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Customer temp = new();
                                temp.Id = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                if (reader.IsDBNull(3)) temp.Country = "NULL";
                                else temp.Country = reader.GetString(3);
                                if (reader.IsDBNull(4)) temp.Phone = "NULL";
                                else temp.Phone = reader.GetString(4);
                                if (reader.IsDBNull(5)) temp.Country = "NULL";
                                else temp.Email = reader.GetString(5);
                                customers.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "UPDATE Customer SET " +
                        "FirstName = @FirstName, " +
                        "LastName = @LastName, " +
                        "Country = @Country, " +
                        "PostalCode = @PostalCode, " +
                        "Phone = @Phone, " +
                        "Email = @Email " +
                        "WHERE CustomerId = @CustomerId;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customer.Id);
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public List<CustomerCountry> GetCountryCounts()
        {
            List<CustomerCountry> countries = new List<CustomerCountry>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "SELECT Country, COUNT(DISTINCT CustomerId)" +
                        " FROM Customer " +
                        "GROUP BY Country " +
                        "ORDER BY COUNT(CustomerId) DESC;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry country = new CustomerCountry();
                                country.CountryName = reader.GetString(0);
                                country.CustomerCount = reader.GetInt32(1);
                                countries.Add(country);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return countries;
        }

        public List<CustomerSpender> GetCustomerSpending()
        {
            List<CustomerSpender> customerSpendings = new List<CustomerSpender>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "SELECT CustomerId, SUM(Total) " +
                        "FROM Invoice " +
                        "GROUP BY CustomerId " +
                        "ORDER BY SUM(Total) DESC";
                        
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender spender = new CustomerSpender();
                                spender.CustomerId = reader.GetInt32(0);
                                spender.TotalSpending = reader.GetDecimal(1);
                                customerSpendings.Add(spender);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerSpendings;
        }

        public List<CustomerGenre> GetCustomerGenres()
        {
            List<CustomerGenre> customerGenres = new List<CustomerGenre>();
            List<CustomerGenre> topGenres = new List<CustomerGenre>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();

                    string sql =
                        "SELECT COUNT(Genre.Name) as Counts, Invoice.CustomerId as CId, Genre.Name as GName " +
                        "FROM Invoice " +
                        "INNER JOIN InvoiceLine " +
                        "ON Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                        "INNER JOIN Track " +
                        "ON InvoiceLine.TrackId = Track.TrackId " +
                        "INNER JOIN Genre " +
                        "ON Track.GenreId = Genre.GenreId " +
                        "GROUP BY Genre.Name, Invoice.CustomerId " +
                        "ORDER BY CId, Counts DESC;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int counts;
                            int customerId;
                            string genre;

                            while (reader.Read())
                            {   
                                counts = reader.GetInt32(0);
                                customerId = reader.GetInt32(1);
                                genre = reader.GetString(2);

                                CustomerGenre temp = new()
                                {
                                    CustomerId = customerId,
                                    Genre = genre,
                                    Count = counts
                                };

                                customerGenres.Add(temp);
                            }
                        }
                    }
                    string genreString = customerGenres[0].Genre;
                    int id = customerGenres[0].CustomerId;
                    int count = customerGenres[0].Count;
                    foreach (CustomerGenre customer in customerGenres)
                    {
                        if (!(id == customer.CustomerId))
                        {
                            CustomerGenre temp = new()
                            {
                                CustomerId = id,
                                Genre = genreString,
                                Count = count
                            };
                            topGenres.Add(temp);

                            id = customer.CustomerId;
                            genreString = customer.Genre;
                            count = 0;
                        }
                        else
                        {
                            if (customer.Count > count)
                            {
                                genreString = customer.Genre;
                            } else if (customer.Count == count)
                            {
                                genreString += ", " + customer.Genre;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return topGenres;
        }
    }
}
