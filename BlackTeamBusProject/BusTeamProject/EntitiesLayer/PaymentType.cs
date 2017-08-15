using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class PaymentType
    {
        public int? ID { get; set; }
        public string PaymentTypeName { get; set; }
        public override string ToString()
        {
            return ID+" "+PaymentTypeName;
        }

    }
}
