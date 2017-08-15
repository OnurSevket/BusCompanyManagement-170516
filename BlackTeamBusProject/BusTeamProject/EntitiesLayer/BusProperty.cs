using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
   public class BusProperty
    {
       //Ara Tablolar için Constructor medtod'a bir instance alınarak bu liste Public Field olarak tutuldu.
        public BusProperty()
        {
            busTypeList = new List<BusType>();
        }

        public int? ID { get; set; }

        public string Name { get; set; }

        
        private List<BusType> busTypeList;
        public List<BusType> BusTypeList
        {
            get { return busTypeList; }
            set { busTypeList = value; }
        }
        public override string ToString()
        {
            return ID+" "+Name;
        }

    }
}
