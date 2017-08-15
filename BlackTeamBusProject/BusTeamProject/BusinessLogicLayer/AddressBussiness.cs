using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AddressBussiness : IBussinessLayer<Address, int>
    {
        AddressDataMapper _addressMapper = new AddressDataMapper();

        public List<Address> GetAllBLL()
        {
            List<Address> allAddress = _addressMapper.GetAll();
            if (allAddress.Count > -1)
                return allAddress;
            else
                throw new Exception("Address listesi boş geldi +002");
        }

        public Address GetBLL(int key)
        {
            Address _address;
            if (key > 0)
            {
                return _address = _addressMapper.Get(key);
            }
            else
                throw new Exception("lütfen seçim yapınız + 002");
        }

        public bool SaveBLL(Address item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #Address +002");
                }
                if (item.City <= 0 || item.City==null)
                {
                    throw new Exception("CityID null geçilemez #Address +002");
                }
                if (item.EmployeeID <= 0|| item.EmployeeID==null)
                {
                    throw new Exception("EmployeeID null geçilemez #Address +002");
                }
                if (item.District <= 0 || item.District==null)
                {
                    throw new Exception("District null geçilemez #Address +002");
                }
                affectedRows = _addressMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Address veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(Address item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (item.ID==null || item.ID<=0)
                {
                    throw new Exception("isim null geçilemez #Address +002");
                }
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new Exception("isim null geçilemez #Address +002");
                }
                if (item.City <= 0 || item.City==null)
                {
                    throw new Exception("CityID null geçilemez #Address +002");
                }
                if (item.EmployeeID <= 0 || item.EmployeeID==null)
                {
                    throw new Exception("EmployeeID null geçilemez #Address +002");
                }
                if (item.District <= 0 || item.District==null)
                {
                    throw new Exception("District null geçilemez #Address +002");
                }
                affectedRows = _addressMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("AddressBusiness de kayıt eklerken bir sorun oluştu");


            }

            return result;
        }

        public bool DeleteBLL(Address item)
        {
            
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _addressMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return true;
                }
                    
            }
            else
                throw new Exception("lütfen seçim yapınız |Address #Delete + 002");
            return result;
        }
    }
}
