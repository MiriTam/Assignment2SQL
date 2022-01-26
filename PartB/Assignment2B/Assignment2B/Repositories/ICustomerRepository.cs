using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2B.Models;

namespace Assignment2B.Repositories
{
    internal interface ICustomerRepository
    {
        /// <summary>
        /// Takes in customer id as an int.
        /// Returns the customer with the given id.
        /// </summary>
        /// <param name="id">Int id of customer.</param>
        /// <returns>Customer object.</returns>
        public Customer GetCustomer(int id);

        /// <summary>
        /// Takes name of a customer as a string.
        /// Returns the customer with the given name.
        /// </summary>
        /// <param name="name">String name of customer.</param>
        /// <returns>Customer object.</returns>
        public Customer GetCustomer(string name);

        /// <summary>
        /// Returns a  list containing all customers in the database.
        /// </summary>
        /// <returns>List of customer objects.</returns>
        public List<Customer> GetAllCustomers();

        /// <summary>
        /// Returns a page of given length with customers.
        /// </summary>
        /// <param name="pageLength">Length of customer page.</param>
        /// <param name="skip">Starting point for customer page.</param>
        /// <returns>List of customers.</returns>
        public List<Customer> GetPageOfCustomers(int pageLength, int skip);

        /// <summary>
        /// Takes in customer id as an int.
        /// Deletes the customer with the given id.
        /// </summary>
        /// <param name="id">Int id of customer.</param>
        /// <returns>Bool indicating if deletion was successfull.</returns>
        public bool DeleteCustomer(int id);

        /// <summary>
        /// Takes in a customer.
        /// Adds the new customer to the database.
        /// </summary>
        /// <param name="customer">String name of customer.</param>
        /// <returns>Bool indicating if insertion was successfull.</returns>
        public bool AddNewCustomer(Customer customer);

        /// <summary>
        /// Updates a customer.
        /// </summary>
        /// <param name="customer">Customer to be updated.</param>
        /// <returns>Bool indicating if update was successfull.</returns>
        public bool UpdateCustomer(Customer customer);
    }
}
