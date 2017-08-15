using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class TravelBussiness : IBussinessLayer<Travel, int>
    {


        TravelDataMapper _travelDataMapper = new TravelDataMapper();

        public List<Travel> GetAllBLL()
        {

            List<Travel> allTravel = _travelDataMapper.GetAll();
            if (allTravel.Count > -1)
            {
                return allTravel;
            }
            else
            {
                throw new Exception("allTravel listesi boş geliyor ");
            }
        }

        public Travel GetBLL(int key)
        {
            if (key > 0)
            {
                Travel travel = _travelDataMapper.Get(key);
                return travel;
            }
            else
            {
                throw new Exception("lütfen seçim yapınız");
            }
        }

        public bool SaveBLL(Travel item)
        {
            int affecttedRows;
            if (item != null)
            {

                if (!Tools.isTravelNumberName(item.TravelNumberName) || item.TravelNumberName == null)
                {
                    throw new Exception("Travel isTravelNumberName Save  yapılamadı + 002 ");
                }
                affecttedRows = _travelDataMapper.Insert(item);
                if (affecttedRows > 0)
                    return affecttedRows > 0;
                else
                    throw new Exception("TravelBussiness veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            else
            {
                throw new Exception("Travel'da item boş geliyor,Save yapılamadı  + 002 ");
            }
        }

        public bool UpdateBLL(Travel item)
        {
            int affecttedRows;
            if (item != null)
            {
                if (item.ID <= 0 && item.ID == null)
                {
                    throw new Exception("Travel ID Update yapılamadı +002");
                }

                if (!Tools.isTravelNumberName(item.TravelNumberName) || item.TravelNumberName == null)
                {
                    throw new Exception("Travel isTravelNumberName Update yapılamadı + 002 ");
                }
                affecttedRows = _travelDataMapper.Update(item);
                if (affecttedRows > 0)
                    return affecttedRows > 0;
                else
                    throw new Exception("TravelBussiness veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            else
            {
                throw new Exception("Travel'da item boş geliyor,Update yapılamadı  + 002 ");
            }
        }

        public bool DeleteBLL(Travel item)
        {
            int affecttedRows;
            bool result = false;
            if (item != null)
            {
                affecttedRows = _travelDataMapper.Delete(item);
                if(affecttedRows > 0)
                {
                    result =  affecttedRows > 0;
                    return result;
                }
                
            }
            else
                throw new Exception("lütfen seçim yapınız");
            return result;
        }



    }
}
