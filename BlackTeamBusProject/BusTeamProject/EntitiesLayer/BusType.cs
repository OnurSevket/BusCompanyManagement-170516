using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class BusType
    {

        //Ara Tablolar için Constructor medtod'a bir instance alınarak bu liste Public Field olarak tutuldu.
        public BusType()
        {
            busPropertList = new List<BusProperty>();
        }

        public int? ID { get; set; }

        public string Name { get; set; }

        public int? BackDoorIndex { get; set; }

        public int? SeatCount { get; set; }

        

        private List<BusProperty> busPropertList;
        public List<BusProperty> BusPropertList
        {
            get { return busPropertList; }
            set { busPropertList = value; }
        }
        public override string ToString()
        {
            return ID+" "+Name;
        }

    }
}
