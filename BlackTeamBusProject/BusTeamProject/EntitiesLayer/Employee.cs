using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Employee
    {


        public Employee()
        {
            officeList = new List<Office>();
            login = new Login();
        }

        public int? ID { get; set; }
        public string SocialNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartWorkDate { get; set; }
        public DateTime FinishWorkDate { get; set; }
        public int? CreatedEmployeeID { get; set; }
        public int? RoleID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public bool? IsAvaible { get; set; }

        private Login login;

        public Login Login
        {
            get { return login; }
            set { login = value; }
        }
        
        
        private List<Office> officeList;

        public List<Office> OfficeList
        {
            get { return officeList; }
            set { officeList = value; }
        }
        public override string ToString()
        {
            return ID+" "+FirstName+" "+LastName;
        }

    }
}
