using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer 
{
    public class LoginBussiness : IBussinessLayer<Login, int>
    {
        LoginDataMapper _loginDataMapper = new LoginDataMapper();

        public bool DeleteBLL(Login item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _loginDataMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else
                throw new Exception("lütfen seçim yapınız |Loign #Delete +002");
            return result;
        }

        public List<Login> GetAllBLL()
        {
            List<Login> allLoginList = _loginDataMapper.GetAll();
            if (allLoginList.Count > -1)
                return allLoginList;

            else
                throw new Exception("lütfen seçim yapınız |Login #listLogin +002");
            
        }

        public Login GetBLL(int key)
        {
            Login useLogin;
            if (key > 0)
            {
                return useLogin = _loginDataMapper.Get(key);
            }
            else
                throw new Exception("hatalı Id girildi |Login #getLogin +002");
        }

        public bool SaveBLL(Login item)
        {
            int affectedRows = 0;
            bool result = false;

            if (item != null)
            {
               
                if (string.IsNullOrWhiteSpace(item.Name))
                    throw new Exception("İsim degeri Boş geçilemez |Login #saveLogin +002 ");
                if (string.IsNullOrWhiteSpace(item.Password))
                    throw new Exception("Password Boş Geçilemez |Login #saveLogin +002 ");

                affectedRows = _loginDataMapper.Insert(item);
                if (affectedRows > 0)
                    result = affectedRows > 0;

                else
                    throw new Exception("District veri tabanına kayıt eklemedi |Login #saveLogin +002");
            }

            return result;
        }

        public bool UpdateBLL(Login item)
        {
            int affectedRows = 0;
            bool result = false;

            if (item != null)
            {
                if (item.ID <= 0 || item.ID == null)
                    throw new Exception("ID degeri null yada Boş geçilemez |Login #Update +002");
                if (string.IsNullOrWhiteSpace(item.Name))
                    throw new Exception("İsim degeri Boş geçilemez |Login #Update +002 ");
                if (string.IsNullOrWhiteSpace(item.Password))
                    throw new Exception("Password Boş Geçilemez |Login #Update +002 ");

                affectedRows = _loginDataMapper.Update(item);
                if (affectedRows > 0)
                    result = affectedRows > 0;

                else
                    throw new Exception("District veri tabanına kayıt Update Eklenmedi |Login #Update +002");
            }

            return result;
        }
    }
}
