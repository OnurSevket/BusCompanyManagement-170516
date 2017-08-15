using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class WorkHour
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public int? EmployeeId { get; set; }

    }
}
