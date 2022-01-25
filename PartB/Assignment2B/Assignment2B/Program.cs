using System;
using Microsoft.Data.SqlClient;
using Assignment2B.Repositories;
using System.Collections.Generic;
using Assignment2B.Models;

namespace Assignment2B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello SQL!");


            CustomerRepository repo = new CustomerRepository();
            List<Customer> liste = repo.GetAllCustomers();
            foreach (Customer customer in liste) Console.WriteLine(customer);

            Console.WriteLine(repo.GetCustomer(6));
            Console.WriteLine(repo.GetCustomer("Bjørn"));
            List<Customer> customersPage = repo.GetPageOfCustomers(5, 3);
            foreach (Customer customer1 in customersPage) Console.WriteLine(customer1);
            
        }

        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new();
            builder.DataSource = "ND-5CG92747KF\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.TrustServerCertificate = true;
            builder.IntegratedSecurity = true;

            return builder.ConnectionString;
        }
    }
}
