using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BusBussiness : IBussinessLayer<Bus, int>
    {
        BusDataMapper _busMapper = new BusDataMapper();


        public List<Bus> GetAllBLL()
        {
            List<Bus> allBus = _busMapper.GetAll();
            if (allBus.Count > -1)
                return allBus;
            else
                throw new Exception("Bus listesi boş geldi +002");
        }

        public Bus GetBLL(int key)
        {
            Bus _bus;
            if (key > 0)
            {
                return _bus = _busMapper.Get(key);
            }
            else
                throw new Exception("lütfen seçim yapınız + 002");
        }

        public bool SaveBLL(Bus item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.Model))
                {
                    throw new Exception("Model null geçilemez #Bus +002");
                }
                if (string.IsNullOrWhiteSpace(item.Brand))
                {
                    throw new Exception("Model null geçilemez #Bus +002");
                }
                if (string.IsNullOrWhiteSpace(item.Plate))
                {
                    throw new Exception("Plaka null geçilemez #Bus +002");
                }
                if (item.Year==null)
                {
                    throw new Exception("Araçın yılı null geçilemez #Bus +002");
                }
                if (item.BusTypeID == null)
                {
                    throw new Exception("Araçın tipi null geçilemez #Bus +002");
                }

                affectedRows = _busMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Bus veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(Bus item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if(item.ID==null|| item.ID<=0)
                {
                    throw new Exception("ID değeri null olamaz");
                }
                if (string.IsNullOrWhiteSpace(item.Model))
                {
                    throw new Exception("Model null geçilemez #Bus +002");
                }
                if (string.IsNullOrWhiteSpace(item.Brand))
                {
                    throw new Exception("Model null geçilemez #Bus +002");
                }
                if (string.IsNullOrWhiteSpace(item.Plate))
                {
                    throw new Exception("Plaka null geçilemez #Bus +002");
                }
                if (item.Year == null)
                {
                    throw new Exception("Araçın yılı null geçilemez #Bus +002");
                }
                if (item.BusTypeID == null)
                {
                    throw new Exception("Araçın tipi null geçilemez #Bus +002");
                }

                affectedRows = _busMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Bus veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool DeleteBLL(Bus item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _busMapper.Delete(item);
                if(affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                    
                }
                    
            }
            else
                throw new Exception("lütfen seçim yapınız  #Delete + 002");
           return result;
        }
    }
}
