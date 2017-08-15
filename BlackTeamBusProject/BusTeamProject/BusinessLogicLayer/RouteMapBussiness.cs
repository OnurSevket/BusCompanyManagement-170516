using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class RouteMapBussiness : IBussinessLayer<RouteMap, int>
    {
        RouteMapDataMapper _routeMapDataMapper = new RouteMapDataMapper();

        public List<RouteMap> GetAllBLL()
        {
            List<RouteMap> allRouteMap = _routeMapDataMapper.GetAll();
            if (allRouteMap.Count > -1)
            {
                return allRouteMap;
            }
            else
            {
                throw new Exception("allRouteMap listesi boş geliyor ");
            }
        }

        public RouteMap GetBLL(int key)
        {
            if (key > 0)
            {
                RouteMap routeMap = _routeMapDataMapper.Get(key);
                return routeMap;
            }
            else
            {
                throw new Exception("lütfen seçim yapınız");
            }
        }

        public bool SaveBLL(RouteMap item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {

                if (item.TravelID <= 0 || item.TravelID == null)
                {
                    throw new Exception("RouteMap TravelID Save yapılamadı + 002 ");
                }
                if (item.Departure <= 0 || item.Departure == null)
                {
                    throw new Exception("RouteMap Departure Save yapılamadı + 002 ");
                }
                if (item.Arrival <= 0 || item.Arrival == null)
                {
                    throw new Exception("RouteMap Arrival Save yapılamadı + 002 ");
                }
                if (item.StartDate == null)
                {
                    throw new Exception("RouteMap StartDate Save yapılamadı + 002 ");
                }
                if (item.EndDate == null)
                {
                    throw new Exception("RouteMap EndDate Save yapılamadı + 002 ");
                }
                if (item.Price <= 0 && item.Price == null)
                {
                    throw new Exception("RouteMap Price Save yapılamadı + 002 ");
                }
                if (item.BeforeRouteID <= 0 && item.BeforeRouteID == null)
                {
                    throw new Exception("RouteMap BeforeRouteID Save yapılamadı + 002 ");
                }
                
                affectedRows = _routeMapDataMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("RouteMap veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(RouteMap item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {

                if (item.TravelID <= 0 || item.TravelID == null)
                {
                    throw new Exception("RouteMap TravelID Save yapılamadı + 002 ");
                }
                if (item.Departure <= 0 || item.Departure == null)
                {
                    throw new Exception("RouteMap Departure Save yapılamadı + 002 ");
                }
                if (item.Arrival <= 0 || item.Arrival == null)
                {
                    throw new Exception("RouteMap Arrival Save yapılamadı + 002 ");
                }
                if (item.StartDate == null)
                {
                    throw new Exception("RouteMap StartDate Save yapılamadı + 002 ");
                }
                if (item.EndDate == null)
                {
                    throw new Exception("RouteMap EndDate Save yapılamadı + 002 ");
                }
                if (item.Price <= 0 && item.Price == null)
                {
                    throw new Exception("RouteMap Price Save yapılamadı + 002 ");
                }
                if (item.BeforeRouteID <= 0 && item.BeforeRouteID == null)
                {
                    throw new Exception("RouteMap BeforeRouteID Save yapılamadı + 002 ");
                }

                affectedRows = _routeMapDataMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("RouteMap veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            return result;
        }

        public bool DeleteBLL(RouteMap item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _routeMapDataMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else  
                {
                    throw new Exception("lütfen seçim yapınız |RouteMap #Delete + 002");
                }
            return result;
        }

    }
}
