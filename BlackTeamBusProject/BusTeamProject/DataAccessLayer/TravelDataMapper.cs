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
    public class TravelDataMapper:IDataMapper<Travel,int>
    {
        SqlCommand _command;

        public TravelDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public Travel Get(int key)
        {
            /*             
                create proc sp_GetTravelByID
                @id int
                as
                select TravelNumberName from Travel where ID=@id                         
             */
            _command.CommandText = "sp_GetTravelByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id",key);
            Travel travel = new Travel();
            try
            {

                if (_command.Connection.State==System.Data.ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                SqlDataReader reader=_command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                      
                        travel.ID = (int)reader["ID"];
                        travel.TravelNumberName = reader.GetString(1);
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Travelları getirirken bir sorun oluştu"+ ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }


            return travel;

        }

        public List<Travel> GetAll()
        {
            /*             
                create proc sp_GetAllTravel
                as
                select * from Travel                        
             */

            List<Travel> travelList = new List<Travel>();
            _command.CommandText = "sp_GetAllTravel";
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
                        Travel travel = new Travel();
                        travel.ID = (int)reader["ID"];
                        travel.TravelNumberName = reader.GetString(1);

                        travelList.Add(travel);
                    }
                }
               
            }
            catch (Exception ex)
            {

                throw new Exception("Travel listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return travelList;
        }

        public int Insert(Travel item)
        {
            int affectedRows = 0;
            /*  
                create proc sp_AddTravel
                @travelNumberName nvarchar(50)
                as
                begin
                Insert into Travel(TravelNumberName) values(@travelNumberName)
                end             
             */
            _command.CommandText = "sp_AddTravel";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@travelNumberName", item.TravelNumberName);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Travel Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;

        }

        public int Update(Travel item)
        {
            /*
                create proc sp_UpdateTravel
                @travelNumberName nchar(8),
                @id int
                as
                begin
                Update Travel set  TravelNumberName=@travelNumberName where ID=@id
                end
            */

            int affectedRows = 0;
            _command.CommandText = "sp_UpdateTravel";
            _command.CommandType = CommandType.StoredProcedure;
            
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.TravelNumberName);
            _command.Parameters.AddWithValue("@id",item.ID);
            

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Travel Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Delete(Travel item)
        {

            /*
               create proc sp_DeleteTravel
               @id int
               as
               begin
               Delete from Travel where ID=@id
               end
           */


            int affectedRows = 0;

            _command.CommandText = "sp_DeleteTravel";
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
                throw new Exception("Travel Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }
    }
}
