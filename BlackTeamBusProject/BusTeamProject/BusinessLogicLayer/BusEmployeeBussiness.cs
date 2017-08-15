using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BusEmployeeBussiness : IBussinessLayer<BusEmployee, int>
    {
        BusEmployeeDataMapper _busEmployeeMapper = new BusEmployeeDataMapper();

        public List<BusEmployee> GetAllBLL()
        {
            List<BusEmployee> allBusEmployee = _busEmployeeMapper.GetAll();
            if (allBusEmployee.Count > -1)
                return allBusEmployee;
            else
                throw new Exception("BusEmployee listesi boş geldi +002");
        }

        public BusEmployee GetBLL(int key)
        {
            BusEmployee _busEmployee;
            if (key > 0)
            {
                return _busEmployee = _busEmployeeMapper.Get(key);
            }
            else
                throw new Exception("lütfen seçim yapınız + 002");
        }

        public bool SaveBLL(BusEmployee item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                
                if (item.CreateDate == null)
                {
                    throw new Exception("CreateDate null geçilemez #Address +002");
                }
                if (item.Employee == null)
                {
                    throw new Exception("Employee null geçilemez #Address +002");
                }
                if (item.RouteMapID == null)
                {
                    throw new Exception("RouteMapID null geçilemez #Address +002");
                }

                affectedRows = _busEmployeeMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("BusEmploye veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(BusEmployee item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (item.BusID == null || item.ID<=0)
                {
                    throw new Exception("BusID null geçilemez #BusEmployee +002");
                }
                if (item.CreateDate == null)
                {
                    throw new Exception("CreateDate null geçilemez #BusEmployee +002");
                }
                if (item.Employee == null)
                {
                    throw new Exception("Employee null geçilemez #BusEmployee +002");
                }
                if (item.RouteMapID == null)
                {
                    throw new Exception("RouteMapID null geçilemez #BusEmployee +002");
                }

                affectedRows = _busEmployeeMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("BusEmploye veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            return result;
        }

        public bool DeleteBLL(BusEmployee item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _busEmployeeMapper.Delete(item);
                if(affectedRows >0)
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
