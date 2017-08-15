using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BusTypeBussiness : IBussinessLayer<BusType, int> 
    {
        BusTypeDataMapper _busTypeMapper = new BusTypeDataMapper();
        public List<BusType> GetAllBLL()
        {
            List<BusType> allBusType = _busTypeMapper.GetAll();
            if (allBusType.Count > -1)
                return allBusType;
            else
                throw new Exception("BusType listesi boş geldi +002");
        }

        public BusType GetBLL(int key)
        {
            BusType _busType;
            if (key > 0)
            {
                return _busType = _busTypeMapper.Get(key);
            }
            else
                throw new Exception("lütfen seçim yapınız + 002");
        }
        public int lastIndex = 0;
        public bool SaveBLL(BusType item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #BusType +002");
                }
                if(item.SeatCount==null || item.SeatCount<=0) //TODO : En az koltuk sayısı girilmesi geekebilir
                {
                    throw new Exception("Koltuk sayısı boş geçilmez #BusType +002");
                }

                affectedRows = _busTypeMapper.Insert(item);
                lastIndex = affectedRows;
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("BusType veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(BusType item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if(item.ID==null)
                {
                    throw new Exception("Güncellenirken Id null geçilmez");
                }
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #BusType +002");
                }
                if (item.SeatCount == null)
                {
                    throw new Exception("Koltuk sayısı boş geçilmez #BusType +002");
                }

                affectedRows = _busTypeMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("BusType veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            return result;
        }

        public bool DeleteBLL(BusType item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _busTypeMapper.Delete(item);
                if(affectedRows >0)
                {
                    result = affectedRows > 0;
                    return result;
                }
               
            }
            else
                throw new Exception("lütfen seçim yapınız #Delete + 002");
            return result;
        }
    }
}
