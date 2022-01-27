using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2B.Models
{
    public class CustomerGenre
    {
        public int CustomerId { get; set; }
        public string Genre { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"Customer: {CustomerId}, Genre: {Genre}";
        }
    }
}
