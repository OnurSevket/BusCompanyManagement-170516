using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class PaymentTypeBussiness : IBussinessLayer<PaymentType, int>
    {
        PaymentTypeDataMapper _payyDataMapper = new PaymentTypeDataMapper();

        public bool DeleteBLL(PaymentType item)
        {
            int affectedRows = 0;
           bool result = false;

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
                throw new Exception("lütfen seçim yapınız |PaymentType #Delete + 002");

            return result;
        }

        public List<PaymentType> GetAllBLL()
        {
            List<PaymentType> allPayment = _payyDataMapper.GetAll();
            if (allPayment.Count > -1)
                return allPayment;

            else
                throw new Exception("lütfen seçim yapınız |PaymentType #List + 002");


        }

        public PaymentType GetBLL(int key)
        {
            PaymentType _paymentType;
            if (key > 0)
             return  _paymentType = _payyDataMapper.Get(key);

            else
                throw new Exception("lütfen seçim yapınız |PaymentType #GetID + 002");
        }

        public bool SaveBLL(PaymentType item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
               
                if (string.IsNullOrWhiteSpace(item.PaymentTypeName))
                    throw new Exception("PaymentTypeName Boş geçilemez |PaymentType #Save + 002");

                affectedRows = _payyDataMapper.Insert(item);

                if (affectedRows > 0)
                    result = affectedRows > 0;

                else
                    throw new Exception("PaymentTypeName Alanına eri eklenemedi |paymentType # Save + 002");

            }
            return result;
        }

        public bool UpdateBLL(PaymentType item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (item.ID <= 0 || item.ID == null)
                    throw new Exception("Id Boş geçilemez |PaymentType #Update + 002");
                if (string.IsNullOrWhiteSpace(item.PaymentTypeName))
                    throw new Exception("PaymentTypeName Boş geçilemez |PaymentType #Update + 002");

                affectedRows = _payyDataMapper.Update(item);

                if (affectedRows > 0)
                    result = affectedRows > 0;

                else
                    throw new Exception("PaymentTypeName Alanına veri eklenemedi |paymentType #Update + 002");

            }
            return result;
        }
    }
}
