using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2B.Models
{
    public class CustomerSpender
    {
        public int CustomerId { get; set; }
        public decimal TotalSpending { get; set; }

        public override string ToString()
        {
            return $"{CustomerId}: {TotalSpending}";
        }
    }
}
