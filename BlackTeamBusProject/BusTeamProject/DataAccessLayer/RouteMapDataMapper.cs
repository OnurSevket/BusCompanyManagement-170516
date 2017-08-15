using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class RouteMapDataMapper : IDataMapper<RouteMap, int>
    {
        SqlCommand _command;

        public RouteMapDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public RouteMap Get(int key)
        {
            /*             
                create proc sp_GetRouteMapByID
                @id int
                as
                select ID,TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID from RouteMap where ID=@id                       
             */
            _command.CommandText = "sp_GetRouteMapByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);
            RouteMap routeMap = new RouteMap();
            try
            {

                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        routeMap.ID = (int)reader[0];
                        routeMap.TravelID = (int)reader[1];
                        routeMap.Departure = (int)reader[2];
                        routeMap.Arrival = (int)reader[3];
                        routeMap.StartDate = Convert.ToDateTime(reader[4]);
                        routeMap.EndDate = Convert.ToDateTime(reader[5]);
                        routeMap.Price = (decimal)reader[6];
                        routeMap.BeforeRouteID = (int)reader["BeforeRouteID"];
 
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("RouteMapleri getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }


            return routeMap;
        }

        public List<RouteMap> GetAll()
        {
            /*             
                create proc sp_GetAllRouteMap
                as
                select ID,TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID from RouteMap                       
             */

            List<RouteMap> routeMapList = new List<RouteMap>();
            _command.CommandText = "sp_GetAllRouteMap";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            try
            {

                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RouteMap routeMap = new RouteMap();
                        routeMap.ID = (int)reader[0];
                        routeMap.TravelID = (int)reader[1];
                        routeMap.Departure = (int)reader[2];
                        routeMap.Arrival = (int)reader[3];
                        routeMap.StartDate = Convert.ToDateTime(reader[4]);
                        routeMap.EndDate = Convert.ToDateTime(reader[5]);
                        routeMap.Price = (decimal)reader[6];
                        routeMap.BeforeRouteID = (int)reader["BeforeRouteID"];

                        routeMapList.Add(routeMap);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("RouteMap listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return routeMapList;
        }

        public int Insert(RouteMap item)
        {
            int affectedRows = 0;
            /*  
                create proc sp_AddRouteMap
                @travelId int,
                @departure int,
                @arrival int,
                @startDate datetime,
                @endDate datetime,
                @price decimal,
                @beforeRouteId int
                as
                begin
                Insert into RouteMap(TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID) values(@travelId,@departure,@arrival,@startDate,@endDate,@price,@beforeRouteId)
                end    
                         
             */
            _command.CommandText = "sp_AddRouteMap";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@travelId", item.TravelID);
            _command.Parameters.AddWithValue("@departure", item.Departure);
            _command.Parameters.AddWithValue("@arrival", item.Arrival);
            _command.Parameters.AddWithValue("@startDate", item.StartDate);
            _command.Parameters.AddWithValue("@endDate", item.EndDate);
            _command.Parameters.AddWithValue("@price", item.Price);
            _command.Parameters.AddWithValue("@beforeRouteId", item.BeforeRouteID);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("RouteMap Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(RouteMap item)
        {
            /*
              
                create proc sp_UpdateRouteMap
                @id int,
                @travelId int,
                @departure int,
                @arrival int,
                @startDate datetime,
                @endDate datetime,
                @price decimal,
                @beforeRouteId int
                as
                begin
                Update RouteMap set TravelID=@travelId,Departure=@departure,Arrival=@arrival,StartDate=@startDate,EndDate=@endDate,Price=@price,BeforeRouteID=@beforeRouteId where ID=@id
                end

             */

            int affectedRows = 0;
            _command.CommandText = "sp_UpdateRouteMap";
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", item.ID);
            _command.Parameters.AddWithValue("@travelId", item.ID);
            _command.Parameters.AddWithValue("@departure", item.Departure);
            _command.Parameters.AddWithValue("@arrival", item.Arrival);
            _command.Parameters.AddWithValue("@startDate", item.StartDate);
            _command.Parameters.AddWithValue("@endDate", item.EndDate);
            _command.Parameters.AddWithValue("@price", item.Price);
            _command.Parameters.AddWithValue("@beforeRouteId", item.BeforeRouteID);


            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("RouteMap Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Delete(RouteMap item)
        {
            /*
                create proc sp_DeleteRouteMap
                @id int
                as
                begin
                Delete from RouteMap where ID=@id
                end
            */


            int affectedRows = 0;

            _command.CommandText = "sp_DeleteRouteMap";
            _command.CommandType = CommandType.StoredProcedure;


            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", item.ID);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("RouteMap Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }
    }
}
