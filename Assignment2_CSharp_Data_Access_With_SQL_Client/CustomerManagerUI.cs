using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_CSharp_Data_Access_With_SQL_Client
{
    public class CustomerManagerUI
    {
        public void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        public void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email} ---");
        }

        public void PrintCustomersInCountry(IEnumerable<CustomersInCountry> customers)
        {
            foreach (CustomersInCountry customer in customers)
            {
                Console.WriteLine($"--- {customer.Country} {customer.CountryCount} ---");
            }
        }

        public void PrintCustomersHighestSpender(IEnumerable<CustomerHighestSpender> customers)
        {
            foreach (CustomerHighestSpender customer in customers)
            {
                Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.TotalSum} ---");
            }
        }

        public void PrintCustomersFavoriteGenre(IEnumerable<CustomerGenre> customers)
        {
            foreach (CustomerGenre customer in customers)
            {
                Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.FavoriteGenre} {customer.GenreCount} ---");
            }
        }

        public void SelectAllCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        public void SelectCustomerById(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerById(15));
        }

        public void SelectCustomerByName(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetCustomerByName("Frank"));
        }

        public void SelectCustomersSubset(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetSubsetCustomers(5, 10));
        }

        public void AddCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer()
            {
                FirstName = "John",
                LastName = "Hendriks",
                Country = "USA",
                PostalCode = "11110",
                Phone = "123456789",
                Email = "john@gmail.com"
            };
            if (repository.AddNewCustomer(customer))
            {
                Console.WriteLine("Customer has been added");
                PrintCustomers(repository.GetCustomerByName("John"));
            }
            else
            {
                Console.WriteLine("Customer could not be added");
            }
        }

        public void UpdateCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer()
            {
                CustomerId = 60,
                FirstName = "Jack"

            };
            if (repository.UpdateCustomer(customer))
            {
                Console.WriteLine("Customer has been updated");
                PrintCustomers(repository.GetCustomerByName("Jack"));
            }
            else
            {
                Console.WriteLine("Customer could not be updated");
            }
        }

        public void SelectCustomersInCountry(ICustomerRepository repository)
        {
            PrintCustomersInCountry(repository.GetCustomersInCountry());
        }

        public void SelectHighestSpenders(ICustomerRepository repository)
        {
            PrintCustomersHighestSpender(repository.GetHighestSpenders());
        }

        public void SelectFavoriteGenre(ICustomerRepository repository)
        {
            PrintCustomersFavoriteGenre(repository.GetPopularGenre(15));
        }
    }
}
