using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class WorkHourBussiness : IBussinessLayer<WorkHour, int>
    {


        WorkHourDataMapper _workHourDataMapper = new WorkHourDataMapper();

        public List<WorkHour> GetAllBLL()
        {

            List<WorkHour> allWorkHour = _workHourDataMapper.GetAll();
            if (allWorkHour.Count > -1)
            {
                return allWorkHour;
            }
            else
            {
                throw new Exception("allWorkHour listesi boş geliyor ");
            }

        }

        public WorkHour GetBLL(int key)
        {

            if (key > 0)
            {
                WorkHour workHour = _workHourDataMapper.Get(key);
                return workHour;
            }
            else
            {
                throw new Exception("lütfen seçim yapınız");
            }
        }

        public bool SaveBLL(WorkHour item)
        {
            int affecttedRows;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.Name) || item.Name == null)
                {
                    throw new Exception("WorkHour Name Save yapılamadı + 002 ");
                }
                if (!Tools.IsHours(item.StartHour) || item.StartHour == null)
                {
                    throw new Exception("WorkHour starthour Save  yapılamadı + 002 ");
                }
                if (!Tools.IsHours(item.EndHour) || item.EndHour == null)
                {
                    throw new Exception("WorkHour EndHour Save yapılamadı + 002 ");
                }
                if (item.EmployeeId <= 0 || item.EmployeeId == null)
                {
                    throw new Exception("WorkHour EmployeeId Save yapılamadı + 002 ");
                }
                affecttedRows = _workHourDataMapper.Insert(item);

                if (affecttedRows > 0)
                {
                    return affecttedRows > 0;
                }
                else
                    throw new Exception("WorkHour veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            else
            {
                throw new Exception("WorkHour'da item boş geliyor,Save yapılamadı  + 002 ");
            }

        }

        public bool UpdateBLL(WorkHour item)
        {
            int affecttedRows;
            if (item != null)
            {
                if (item.ID <= 0 && item.ID == null)
                {
                    throw new Exception("WorkHour ID Update yapılamadı +002");
                }

                if (string.IsNullOrWhiteSpace(item.Name) || item.Name == null)
                {
                    throw new Exception("WorkHour Name Update yapılamadı + 002 ");
                }
                if (!Tools.IsHours(item.StartHour) || item.StartHour == null)
                {
                    throw new Exception("WorkHour starthour Update  yapılamadı + 002 ");
                }
                if (!Tools.IsHours(item.EndHour) || item.EndHour == null)
                {
                    throw new Exception("WorkHour EndHour Update yapılamadı + 002 ");
                }
                if (item.EmployeeId <= 0 || item.EmployeeId == null)
                {
                    throw new Exception("WorkHour EmployeeId Update yapılamadı + 002 ");
                }
                affecttedRows = _workHourDataMapper.Update(item);

                if (affecttedRows > 0)
                {
                    return affecttedRows > 0;
                }
                else
                    throw new Exception("WorkHour veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            else
            {
                throw new Exception("WorkHour'da item boş geliyor,Update yapılamadı  + 002 ");
            }
        }

        public bool DeleteBLL(WorkHour item)
        {
            int affecttedRows;
            bool result = false;
            if (item != null)
            {
                affecttedRows = _workHourDataMapper.Delete(item);
                if (affecttedRows > 0)
                {
                    result = affecttedRows > 0;
                    return result;
                }

            }
            else
                throw new Exception("lütfen seçim yapınız ");
            return result;  
        }
    }
}

