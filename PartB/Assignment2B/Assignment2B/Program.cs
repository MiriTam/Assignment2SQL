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
            //Print all customers.
            CustomerRepository repo = new CustomerRepository();
            List<Customer> liste = repo.GetAllCustomers();
            foreach (Customer customer1 in liste) Console.WriteLine(customer1);

            //Fetch a single customer.
            Console.WriteLine(repo.GetCustomer(6));
            Console.WriteLine(repo.GetCustomer("Bjørn"));

            //Get a page of customers.
            List<Customer> customersPage = repo.GetPageOfCustomers(5, 3);
            foreach (Customer customer2 in customersPage) Console.WriteLine(customer2);

            //Create and add new customer.
            Customer customer3 = new Customer
            {
                Id = 798,
                FirstName = "Miriam",
                LastName = "Aarag",
                Country = "Norge",
                PostalCode = "1386",
                Phone = "113",
                Email = "mkmfwff"
            };
            repo.AddNewCustomer(customer3);
            Console.WriteLine(repo.GetCustomer("Miriam"));

            //Update customer.
            Customer customer4 = repo.GetCustomer("Miriam");
            customer4.FirstName = "Anne";
            customer4.PostalCode = "5012";
            repo.UpdateCustomer(customer4);
            Console.WriteLine(repo.GetCustomer("Anne"));

            //Get number of customers in each country.
            List<CustomerCountry> contries = repo.GetCountryCounts();
            foreach (CustomerCountry country in contries) Console.WriteLine(country);

            //Get total spending for each customer.
            List<CustomerSpender> spends = repo.GetCustomerSpending();
            foreach (CustomerSpender spend in spends) Console.WriteLine(spend);

            //Get most popular genre for each customer.
            List<CustomerGenre> cgs = repo.GetCustomerGenres();
            foreach (CustomerGenre g in cgs) Console.WriteLine(g);
        }

        /// <summary>
        /// Method creates and return the connection string used to connect 
        /// to the database.
        /// </summary>
        /// <returns>Connection string.</returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new();
            //Select string based on which computer the code is executed on.
            //builder.DataSource = "ND-5CG92747KF\\SQLEXPRESS";
            builder.DataSource = "ND-5CG9030MCG\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.TrustServerCertificate = true;
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
        }
    }
}
