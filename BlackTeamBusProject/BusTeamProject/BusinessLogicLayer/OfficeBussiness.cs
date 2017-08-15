using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;



namespace BusinessLogicLayer
{
    public class OfficeBussiness : IBussinessLayer<Office, int>
    {
        OfficeDataMapper _officeMapper = new OfficeDataMapper();

        public bool DeleteBLL(Office item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _officeMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else throw new Exception("lütfen seçim yapınız |Office #delete +002");
            return result;
        }

        public List<Office> GetAllBLL()
        {
            List<Office> allOfficeList = _officeMapper.GetAll();
            if (allOfficeList.Count > -1)
                return allOfficeList;

            else
                throw new Exception("lütfen seçim yapınız |Office #ListOffice +002");
            
        }

        public Office GetBLL(int key)
        {
            Office _office;
            if (key > 0)
            {
                return _office = _officeMapper.Get(key);
            }

            else
                throw new Exception("Hatalı id degeri +002");
        }

        public bool SaveBLL(Office item)
        {
            int affectedRows = 0;
            bool result = false;

            if (item != null)
            {
                
                if (string.IsNullOrWhiteSpace(item.OfficeName))
                    throw new Exception("OfficeName boş geçilemez |Office #Save +002");
                if (item.DistictID < 0 || item.DistictID == null)
                    throw new Exception("DistincId Boş Geçilemez |Office #Save +002");
                if (item.IsCenterOffice == null)
                    throw new Exception("CenterOffice Hatası |Office #Save +002");

                affectedRows = _officeMapper.Insert(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Login Veri Tabanına veri Eklenme Hatası |Office #Save +002");
            }
            return result;
        }

        public bool UpdateBLL(Office item)
        {
            int affectedRows = 0;
            bool result = false;

            if (item != null)
            {
                if (item.ID < 0 || item.ID == null)
                {
                    throw new Exception("ID boş geçilemez |Office #Update +002");
                }
                if (string.IsNullOrWhiteSpace(item.OfficeName))
                    throw new Exception("OfficeName boş geçilemez |Office #Update +002");
                if (item.DistictID < 0 || item.DistictID == null)
                    throw new Exception("DistincId Boş Geçilemez |Office #Update +002");
                if (item.IsCenterOffice == null)
                    throw new Exception("CenterOffice Hatası |Office #Update +002");

                affectedRows = _officeMapper.Update(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Login Veri Tabanına veri Eklenme Hatası |Office #Update +002");
            }
            return result;
        }
    }
}
