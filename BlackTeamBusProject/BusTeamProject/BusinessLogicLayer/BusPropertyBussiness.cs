using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BusPropertyBussiness : IBussinessLayer<BusProperty, int>
    {
        BusPropertyDataMapper _busPropertyMapper = new BusPropertyDataMapper();
        public List<BusProperty> GetAllBLL()
        {
            List<BusProperty> allBusPropery = _busPropertyMapper.GetAll();
            if (allBusPropery.Count > -1)
                return allBusPropery;
            else
                throw new Exception("BusPropery listesi boş geldi +002");
        }

        public BusProperty GetBLL(int key)
        {
            BusProperty _busProperty;
            if (key > 0)
            {
                return _busProperty = _busPropertyMapper.Get(key);
            }
            else
                throw new Exception("lütfen seçim yapınız");
        }

        public bool SaveBLL(BusProperty item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #Address +002");
                }

                affectedRows = _busPropertyMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("BusProperty veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(BusProperty item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if(item.ID==null || item.ID<=0)
                {
                    throw new Exception("Güncellenirken Id null geçilmez");
                }
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #BusProperty +002");
                }

                affectedRows = _busPropertyMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("BusProperty veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool DeleteBLL(BusProperty item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _busPropertyMapper.Delete(item);
                if(affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
                
            }
            else
                throw new Exception("lütfen seçim yapınız");
            return result;
        }
    }
}
