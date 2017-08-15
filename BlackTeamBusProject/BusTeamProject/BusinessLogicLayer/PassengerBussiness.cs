using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class PassengerBussiness : IBussinessLayer<Passenger, int>
    {
        PassengerDataMapper _passDataMapper = new PassengerDataMapper();

        public bool DeleteBLL(Passenger item)
        {
            int affectedRows = 0;
            bool result = false;

            if (item != null)
            {
                affectedRows = _passDataMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else
                throw new Exception("lütfen seçim yapınız |Passanger #Delete + 002");

            return result;
        }

        public List<Passenger> GetAllBLL()
        {
            List<Passenger> allPassengerlist = _passDataMapper.GetAll();
            if (allPassengerlist.Count > -1)
                return allPassengerlist;

            else
                throw new Exception("lütfen seçim yapınız |Passenger #List +002");

        }

        public Passenger GetBLL(int key)
        {
            Passenger _passenger;
            if (key > 0)
                return _passenger = _passDataMapper.Get(key);

            else
                throw new Exception("Hatalı id degeri |Passenger  #Get +002");
        }

        public bool SaveBLL(Passenger item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
               
                if(string.IsNullOrWhiteSpace(item.SocialNumber))
                    throw new Exception("SocialNumber Null geçilemez |Passenger #Save +002");
                if(string.IsNullOrWhiteSpace(item.FirstName))
                    throw new Exception("FirstName Null geçilemez |Passenger #Save +002");
                if(string.IsNullOrWhiteSpace(item.LastName))
                    throw new Exception("LastName Null geçilemez |Passenger #Save +002");
                if( item.Gender == null)
                    throw new Exception("Gender Null geçilemez |Passenger #Save +002");
                if(string.IsNullOrWhiteSpace(item.Telephone))
                    throw new Exception("Telefon Null geçilemez |Passenger #Save +002");
                if(string.IsNullOrWhiteSpace(item.Email))
                    throw new Exception("Email Null geçilemez |Passenger #Save +002");

                affectedRows = _passDataMapper.Insert(item);
                if (affectedRows > 0)
                    result = affectedRows > 0;

                else
                    throw new Exception("Veri Tabanında kayı bulunamadı |Passenger #Save +002");
            }
            return result;
        }

        public bool UpdateBLL(Passenger item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (item.ID <= 0 || item.ID == null)
                    throw new Exception("ID Null geçilemez |Passenger #Update +002");
                if (string.IsNullOrWhiteSpace(item.SocialNumber))
                    throw new Exception("SocialNumber Null geçilemez |Passenger #Update +002");
                if (string.IsNullOrWhiteSpace(item.FirstName))
                    throw new Exception("FirstName Null geçilemez |Passenger #Update +002");
                if (string.IsNullOrWhiteSpace(item.LastName))
                    throw new Exception("LastName Null geçilemez |Passenger #Update +002");
                if (item.Gender == null)
                    throw new Exception("Gender Null geçilemez |Passenger #Update +002");
                if (string.IsNullOrWhiteSpace(item.Telephone))
                    throw new Exception("Telefon Null geçilemez |Passenger #Update +002");
                if (string.IsNullOrWhiteSpace(item.Email))
                    throw new Exception("Email Null geçilemez |Passenger #Update +002");

                affectedRows = _passDataMapper.Update(item);
                if (affectedRows > 0)
                    result = affectedRows > 0;

                else
                    throw new Exception("Veri Tabanında kayı bulunamadı |Passenger #Update +002");
            }
            return result;
        }
    }
}
