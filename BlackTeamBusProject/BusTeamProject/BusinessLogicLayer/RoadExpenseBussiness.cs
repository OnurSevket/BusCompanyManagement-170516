using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class RoadExpenseBussiness : IBussinessLayer<RoadExpense, int>
    {
        RoadExpenseDataMapper _roadExpenseDataMapper = new RoadExpenseDataMapper();

        public bool DeleteBLL(RoadExpense item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _roadExpenseDataMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else
                throw new Exception("lütfen seçim yapınız |RoadExpense #Delete + 002");
            return result;
        }

        public List<RoadExpense> GetAllBLL()
        {
            List<RoadExpense> allRoadExpense = _roadExpenseDataMapper.GetAll();
            if (allRoadExpense.Count > -1)
                return allRoadExpense;
            else
                throw new Exception("lütfen seçim yapınız |RoadExpense #GetAll + 002");

        }

        public RoadExpense GetBLL(int key)
        {
            RoadExpense _roadExpense;
            if (key >0)
            {
                return _roadExpense = _roadExpenseDataMapper.Get(key);
            }
            else
                throw new Exception("GetID Hatası |RoadExpense #GetID + 002");

        }

        public bool SaveBLL(RoadExpense item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                
                if(item.BusID <= 0 || item.BusID == null)
                    throw new Exception("BusId Alanı boş geçilemez |RoadExpense #Save + 002");
                if (string.IsNullOrWhiteSpace(item.ExpenseName))
                    throw new Exception("ExpenseName Boş geçilemez |RoadExpense #Save + 002");
                if (item.TotalPrice <= 0 || item.TotalPrice == null)
                    throw new Exception("TotalPrice Boş geçilemez |RoadExpense #Save + 002");

                affectedRows = _roadExpenseDataMapper.Insert(item);

                if (affectedRows > 0)
                    result = affectedRows > 0;

                else
                    throw new Exception("Road Expense veri tabanına veri ekelemedi |RoadExpense #Save + 002");

            }
            return result;
        }

        public bool UpdateBLL(RoadExpense item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (item.ID <= 0 || item.ID == null)
                    throw new Exception("Id Alanı boş geçilemez |RoadExpense #Update + 002");
                if (item.BusID <= 0 || item.BusID == null)
                    throw new Exception("BusId Alanı boş geçilemez |RoadExpense #Update + 002");
                if (string.IsNullOrWhiteSpace(item.ExpenseName))
                    throw new Exception("ExpenseName Boş geçilemez |RoadExpense #Update + 002");
                if (item.TotalPrice <= 0 || item.TotalPrice == null)
                    throw new Exception("TotalPrice Boş geçilemez |RoadExpense #Update + 002");

                affectedRows = _roadExpenseDataMapper.Update(item);

                if (affectedRows > 0)
                    result = affectedRows > 0;

                else
                    throw new Exception("Road Expense veri tabanına veri ekelemedi |RoadExpense #Update + 002");

            }
            return result;
        }
    }
}
