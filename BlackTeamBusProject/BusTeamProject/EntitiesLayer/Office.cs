using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Office
    {


        public Office()
        {
            employeeList = new List<Employee>();
        }

        public int? ID { get; set; }
        public string OfficeName { get; set; }
        public int? DistictID { get; set; }
        public bool? IsCenterOffice { get; set; }


        private List<Employee> employeeList;

        public List<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }
        public override string ToString()
        {
            return ID+" "+OfficeName;
        }
    }
}
