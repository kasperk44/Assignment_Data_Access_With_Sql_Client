using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_CSharp_Data_Access_With_SQL_Client
{
    public class CustomerHighestSpender
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Decimal TotalSum { get; set; }
    }
}
