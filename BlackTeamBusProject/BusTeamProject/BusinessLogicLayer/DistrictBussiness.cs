using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DistrictBusiness : IBussinessLayer<District, int>
    {
       
        DistrictDataMapper _districtMapper = new DistrictDataMapper();

        public bool DeleteBLL(District item)
        {
            int affectedRows = 0;

            bool result = false;
            if (item != null)
            {
                affectedRows = _districtMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else
                throw new Exception("lütfen seçim yapınız |District #Delete + 002");
            return result;
        }

        public List<District> GetAllBLL()  
        {
            List<District> allDistrict = _districtMapper.GetAll();
            if (allDistrict.Count > -1)
                return allDistrict;

            else
                throw new Exception("lütfen seçim yapınız |District #ListDistrict +002");
        }

        public District GetBLL(int key)
        {
            District _district;
            if (key > 0)
            {
                return _district = _districtMapper.Get(key);
            }
            else
                throw new Exception("Hatalı id degeri + 002");
        }

        public bool SaveBLL(District item)
        {
            int affectedRows = 0;

            bool result = false;
            if (item != null)
            {
                
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #District +002");
                }
                if (item.CityID <= 0 || item.CityID==null)
                {
                    throw new Exception("CityID null geçilemez #District +002");
                }
                affectedRows = _districtMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("District veri tabanında Hiçbir kayıt etkilenmedi #Insert");
                
            }

            return result;  
        }

        public bool UpdateBLL(District item)
        {
            int affectedRows = 0;

            bool result = false;
            if (item != null)
            {
                if (item.ID <= 0 || item.ID == null)
                    throw new Exception("Id Alanı boş geçilemez |District #Save + 002");
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #District +002");
                }
                if (item.CityID <= 0)
                {
                    throw new Exception("CityID null geçilemez #District +002");
                }

                affectedRows = _districtMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("District veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }

            return result;  //result döndür geriye 
        }

        
    }
}
