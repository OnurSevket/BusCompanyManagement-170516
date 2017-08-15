using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
   public class RoadExpense
    {

       public int? ID { get; set; }

        public string ExpenseName { get; set; }

        public int? BusID { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
