using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AuthoryBussiness : IBussinessLayer<Authory, int>
    {
        AuthoryDataMapper _authoryMapper = new AuthoryDataMapper();

        public List<Authory> GetAllBLL()
        {
            List<Authory> allAuthory = _authoryMapper.GetAll();
            if (allAuthory.Count > -1)
                return allAuthory;
            else
                throw new Exception("Author listesi boş geldi +002");
        }

        public Authory GetBLL(int key)
        {
            Authory _authory;
            if (key > 0)
            {
                return _authory = _authoryMapper.Get(key);
            }
            else
                throw new Exception("lütfen seçim yapınız + 002");
        }

        public bool SaveBLL(Authory item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.AuthoryName))
                {
                    throw new Exception("isim null geçilemez #Address +002");
                }

                affectedRows = _authoryMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Authory veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(Authory item)
        {
            int affectedRows = 0;
            bool result = false;
            {
                if(item.ID<=0 || item.ID==null)
                {
                    throw new Exception("ID null geçilemez");
                }
                if (string.IsNullOrWhiteSpace(item.AuthoryName))
                {
                    throw new Exception("isim null geçilemez #Address +002");
                }

                affectedRows = _authoryMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Authory veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            return result;
        }

        public bool DeleteBLL(Authory item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _authoryMapper.Delete(item);
                if(affectedRows > 0)
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
