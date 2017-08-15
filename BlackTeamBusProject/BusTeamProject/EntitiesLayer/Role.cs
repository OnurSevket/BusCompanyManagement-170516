using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Role
    {
        public Role()
        {
            authoryList = new List<Authory>();
        }
        public int? ID { get; set; }

        public string RoleName { get; set; }
    
        private List<Authory> authoryList;
        public List<Authory> AuthoryList
        {
            get { return authoryList; }
            set { authoryList = value; }
        }

    }

}
