using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class OrdersAndUserViewModel
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateTime { get; set; }
        public int OrderCount { get; set; }
        public byte Status { get; set; }
    }
}