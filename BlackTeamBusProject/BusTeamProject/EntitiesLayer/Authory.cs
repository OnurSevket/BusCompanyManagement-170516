using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Authory
    {
        public Authory()
        {
            roleList = new List<Role>();
        }
        public int? ID { get; set; }

        public string AuthoryName { get; set; }
       

        private List<Role> roleList;

        public List<Role> RoleList
        {
            get { return roleList; }
            set { roleList = value; }
        }
        public override string ToString()
        {
            return ID+" "+AuthoryName;
        }


    }
}
