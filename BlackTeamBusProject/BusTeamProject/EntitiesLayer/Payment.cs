using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Payment
    {
        public int? ID { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? PaymentTypeID { get; set; }
        public DateTime CreatePaymentDate { get; set; }

    }
}
