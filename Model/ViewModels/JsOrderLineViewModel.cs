using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class JsOrderLineViewModel
    {
        public int OrderLineId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
