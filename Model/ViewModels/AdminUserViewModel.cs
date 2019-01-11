using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    class AdminUserViewModel
    {
        public User user { get; set; }
        public List<Order> orders { get; set; }
        public List<OrderLine> orderline { get; set; }
    }
}
