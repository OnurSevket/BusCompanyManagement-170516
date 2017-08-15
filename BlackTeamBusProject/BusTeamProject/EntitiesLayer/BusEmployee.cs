using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class BusEmployee
    {
        public int? ID { get; set; }

        public int? BusID { get; set; }

        public int? Employee { get; set; }

        public DateTime CreateDate { get; set; }

        public int? RouteMapID { get; set; }

    }
}
