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
        /// Takes in an int, id of a customer.
        /// Returns the customer with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomer(int id);
        /// <summary>
        /// Takes in a string, name of a customer.
        /// Returns the customer with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer GetCustomer(string name);
        /// <summary>
        /// Returns a  list containing all customers in the database.
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers();
        /// <summary>
        /// Returns a page of customeers that is the specified length long
        /// </summary>
        /// <param name="pageLength"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<Customer> GetPageOfCustomers(int pageLength, int skip);
        /// <summary>
        /// Takes in an int, id of a customer.
        /// Deletes the customer with the given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int id);
        /// <summary>
        /// Takes in a customer.
        /// Adds the new customer to the database.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool AddNewCustomer(Customer customer);
        /// <summary>
        /// Updates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(Customer customer);

    }
}
