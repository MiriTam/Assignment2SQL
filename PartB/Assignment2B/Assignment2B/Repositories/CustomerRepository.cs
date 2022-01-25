﻿using System;
using System.Collections.Generic;
using Assignment2B.Models;
using Microsoft.Data.SqlClient;

namespace Assignment2B.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        public bool AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer( int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.GetConnectionString()))
                {
                    connection.Open();
                    Console.WriteLine("Connection open.");

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
                    Console.WriteLine("Connection open.");

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
                    Console.WriteLine("Connection open.");

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
                    Console.WriteLine("Connection open.");

                    string sql = //$"SELECT ALL CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer;" +
                        $"DECLARE cursor CURSOR FOR" +
                        $"SELECT ALL CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer;" +
                        $"OPEN cursor;" +
                        $"FETCH NEXT FROM cursor;";
                        //$"@pageLength;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@pageLength", pageLength);
                        //command.Parameters.AddWithValue("@skip", skip);
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
            throw new NotImplementedException();
        }
    }
}