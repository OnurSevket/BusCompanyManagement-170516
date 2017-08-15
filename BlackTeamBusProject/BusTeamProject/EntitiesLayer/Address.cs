using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
  public  class Address
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int? City { get; set; }
        public int? District { get; set; }
        public int? EmployeeID { get; set; }
        public override string ToString()
        {
            return ID+" "+Name;
        }
    }
}
