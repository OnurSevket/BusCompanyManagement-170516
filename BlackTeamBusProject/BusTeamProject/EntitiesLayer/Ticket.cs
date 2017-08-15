using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Ticket
    {
        public int? ID { get; set; }
        public int? PassangerID { get; set; }
        public int? RouteMapID { get; set; }
        public int? TravelID { get; set; }
        public int? EmployeeID { get; set; }
        public int? BusSeatID { get; set; }
        public DateTime CreateTicketDate { get; set; }
        public int? PaymentID { get; set; }
    }
}
