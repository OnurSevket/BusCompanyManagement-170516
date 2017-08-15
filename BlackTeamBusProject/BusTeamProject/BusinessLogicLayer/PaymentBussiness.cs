using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class PaymentBussiness : IBussinessLayer<Payment, int>
    {
        PaymentDataMapper _payyDataMapper = new PaymentDataMapper();

        public bool DeleteBLL(Payment item)
        {
            int affectedRows = 0;
            bool result= false;
            if (item != null)
            {
                affectedRows = _payyDataMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else
                throw new Exception("lütfen seçim yapınız |payment #Delete +002");

            return result;
        }

        public List<Payment> GetAllBLL()
        {
            List<Payment> allPaymenList = _payyDataMapper.GetAll();
            if (allPaymenList.Count > -1)
                return allPaymenList;
            else
                throw new Exception("lütfen seçim yapınız |payment #List +002");
        }

        public Payment GetBLL(int key)
        {
            Payment _payment;
            if (key > 0)
                return _payment = _payyDataMapper.Get(key);

            else
                throw new Exception("GetId hatası |payment #GetID +002");
        }

        public bool SaveBLL(Payment item)
        {
            bool result = false;
           int affectedRows = 0;
            if (item != null)
            {
               
                if(item.PaymentTypeID <= 0 || item.PaymentTypeID == null)
                    throw new Exception("PaymmentID Boş Geçilemez |payment #Save +002");
                if(item.TotalPrice <= 0 || item.TotalPrice == null)
                    throw new Exception("TotalPcice Boş Geçilemez |payment #Save +002");
                if(item.CreatePaymentDate == null)
                    throw new Exception("CreatePaymentDate Boş Geçilemez |payment #Save +002");
                affectedRows = _payyDataMapper.Insert(item);

                if (affectedRows > 0)
                    result = affectedRows > 0;
                else
                    throw new Exception("veri tabanına kayıt eklenmedi |payment #Save +002");
            }
            return result;
        }

        public bool UpdateBLL(Payment item)
        {
            bool result = false;
            int affectedRows = 0;
            if (item != null)
            {
                if (item.ID <= 0 || item.ID == null)
                    throw new Exception("ID Boş Geçilemez |payment #Update +002");
                if (item.PaymentTypeID <= 0 || item.PaymentTypeID == null)
                    throw new Exception("PaymmentID Boş Geçilemez |payment #Update +002");
                if (item.TotalPrice <= 0 || item.TotalPrice == null)
                    throw new Exception("TotalPcice Boş Geçilemez |payment #Update +002");
                if (item.CreatePaymentDate == null)
                    throw new Exception("CreatePaymentDate Boş Geçilemez |payment #Update +002");
                affectedRows = _payyDataMapper.Update(item);

                if (affectedRows > 0)
                    result = affectedRows > 0;
                else
                    throw new Exception("veri tabanına kayıt eklenmedi |payment #Save +002");
            }
            return result;
        }
    }
}
