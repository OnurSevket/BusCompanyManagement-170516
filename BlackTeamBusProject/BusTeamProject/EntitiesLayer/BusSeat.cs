using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
   public class BusSeat
    {
       public int? ID { get; set; }

        public int? BusID { get; set; }

        public int? BusTypeID { get; set; }

        public int? SeatNumber { get; set; }

        public bool? IsWindow { get; set; }

    }
}
