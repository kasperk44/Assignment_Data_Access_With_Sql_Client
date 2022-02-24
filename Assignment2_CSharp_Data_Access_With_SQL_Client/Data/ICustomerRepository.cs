using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_CSharp_Data_Access_With_SQL_Client
{
    public interface ICustomerRepository
    {
        //Read all customers
        public List<Customer> GetAllCustomers();

        //Read specific customer by id
        public Customer GetCustomerById(int id);

        //Read specific customer by name
        public List<Customer> GetCustomerByName(string firstName);

        //Read customers with limit and offset as parameters
        public List<Customer> GetSubsetCustomers(int offset, int limit);

        //Add new customer
        public bool AddNewCustomer(Customer customer);

        //Update existing customer
        public bool UpdateCustomer(Customer customer);

        //Return number of customers in each country ordered descending.
        public List<CustomersInCountry> GetCustomersInCountry();

        //Return highest spenders ordered descending.
        public List<CustomerHighestSpender> GetHighestSpenders();

        //Return most popular genre for a given customer
        public List<CustomerGenre> GetPopularGenre(int id);

    }

}
