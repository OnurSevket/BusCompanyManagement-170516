using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
   public class RouteMap
    {
       public RouteMap()
       {
           routeMap = new List<RouteMap>();
       }
       public int? ID { get; set; }

       public int? TravelID { get; set; }

       public int? Departure { get; set; }

       public int? Arrival { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal? Price { get; set; }

        public int? BeforeRouteID { get; set; }

        public List<RouteMap> routeMap;
        public override string ToString()
        {
            return " Kalkış :"+Departure+" Varış:"+Arrival;
        }
    }
}
