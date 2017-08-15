using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
   public  class Bus
    {
        public int? ID { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime Year { get; set; }

        public int? BusTypeID { get; set; }

        public string Plate { get; set; }
        public override string ToString()
        {
            return ID+" "+Brand+" "+Model;
        }

    }
}
