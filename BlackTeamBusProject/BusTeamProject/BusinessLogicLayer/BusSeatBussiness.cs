using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BusSeatBussiness : IBussinessLayer<BusSeat, int>
    {
        BusSeatDataMapper _busSeatMapper = new BusSeatDataMapper();
        public List<BusSeat> GetAllBLL()
        {
            List<BusSeat> allBusSeat = _busSeatMapper.GetAll();
            if (allBusSeat.Count > -1)
                return allBusSeat;
            else
                throw new Exception("Bus Seat listesi boş geldi +002");
        }

        public BusSeat GetBLL(int key)
        {
            BusSeat _busProperty;
            if (key > 0)
            {
                return _busProperty = _busSeatMapper.Get(key);
            }
            else
                throw new Exception("lütfen seçim yapınız + 002");
        }

        public bool SaveBLL(BusSeat item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (item.BusTypeID==null ||item.BusTypeID<=0)
                {
                    throw new Exception("BusType null geçilemez #Address +002");
                }
                if(item.BusID==null || item.BusID<=0)
                {
                    throw new Exception("BusID null geçilemez");
                }
                if(item.IsWindow==null  )
                {
                    throw new Exception("IsWindow alanı boş geçilmez");
                }
                if(item.SeatNumber==null || item.SeatNumber<=0)
                {
                    throw new Exception("SeatNumber alanı boş geçilmez");
                }

                affectedRows = _busSeatMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("BusSeat veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(BusSeat item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if(item.ID==null||item.ID<=0)
                {
                    throw new Exception("Güncelenirken Id değeri boş olmamalıdır");
                }
                if (item.BusTypeID == null || item.BusTypeID<=0)
                {
                    throw new Exception("BusType null geçilemez #Address +002");
                }
                if (item.BusID == null || item.BusID<=0)
                {
                    throw new Exception("BusID null geçilemez");
                }
                if (item.IsWindow == null)
                {
                    throw new Exception("IsWindow alanı boş geçilmez");
                }
                if (item.SeatNumber == null || item.SeatNumber<=0)
                {
                    throw new Exception("SeatNumber alanı boş geçilmez");
                }

                affectedRows = _busSeatMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("BusSeat veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            return result;
        }

        public bool DeleteBLL(BusSeat item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _busSeatMapper.Delete(item);
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
