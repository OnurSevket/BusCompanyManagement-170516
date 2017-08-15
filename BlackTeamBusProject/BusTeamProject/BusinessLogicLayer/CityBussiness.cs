using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CityBussiness : IBussinessLayer<City, int>
    {
        CityDataMapper _cityDataMapper = new CityDataMapper();

        public List<City> GetAllBLL()
        {
            List<City> allCity = _cityDataMapper.GetAll();
            if (allCity.Count > -1)
                return allCity;
            else
                throw new Exception("allCity listesi boş geldi +002");
        }

        public City GetBLL(int key)
        {
            City _city;
            if (key > 0)
            {
                return _city = _cityDataMapper.Get(key);
            }
            else
                throw new Exception("lütfen seçim yapınız + 002");
        }

        public bool SaveBLL(City item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #City +002");
                }

                affectedRows = _cityDataMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("City veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(City item)
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
                    throw new Exception("isim null geçilemez #City +002");
                }

                affectedRows = _cityDataMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("City veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            return result;
        }

        public bool DeleteBLL(City item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _cityDataMapper.Delete(item);
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
