using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Passenger
    {
        public Passenger()
        {
            login = new LoginPassenger();
        }
        public int? ID { get; set; }
        public string SocialNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        private LoginPassenger login;

        public LoginPassenger Login
        {
            get { return login; }
            set { login = value; }
        }
        
        
        public override string ToString()
        {
            return ID+" "+FirstName+" "+LastName;
        }


    }
}
