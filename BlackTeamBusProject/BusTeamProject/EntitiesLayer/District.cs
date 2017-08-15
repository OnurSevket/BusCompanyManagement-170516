using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
   public class District
    {
       public int? ID { get; set; }

        public string Name { get; set; }

        public int? CityID { get; set; }
        public override string ToString()
        {
            return ID+" "+Name;
        }
    }
}
