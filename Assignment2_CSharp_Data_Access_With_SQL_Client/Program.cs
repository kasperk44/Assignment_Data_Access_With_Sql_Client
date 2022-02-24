using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Assignment2_CSharp_Data_Access_With_SQL_Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManagerUI start = new CustomerManagerUI();

            ICustomerRepository repository = new CustomerRepository();

            //1
            start.SelectAllCustomers(repository);

            //2
            start.SelectCustomerById(repository);

            //3
            start.SelectCustomerByName(repository);

            //4
            start.SelectCustomersSubset(repository);

            //5
            start.AddCustomer(repository);

            //6
            start.UpdateCustomer(repository);

            //7
            start.SelectCustomersInCountry(repository);

            //8
            start.SelectHighestSpenders(repository);

            //9
            start.SelectFavoriteGenre(repository);
        }
    }
}
