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
    public class WorkHourDataMapper : IDataMapper<WorkHour, int>
    {
        SqlCommand _command;

        public WorkHourDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public WorkHour Get(int key)
        {
            /*             
                 create proc sp_GetWorkHourByID
                 @id int
                 as
                 select ID,Name,StartHour,EndHour,EmployeeID from WorkHour where ID=@id                         
              */
            _command.CommandText = "sp_GetWorkHourByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);
            WorkHour workHour = new WorkHour();
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

                        workHour.ID = (int)reader["ID"];
                        workHour.Name = reader.GetString(1);
                        workHour.StartHour = reader.GetString(2);
                        workHour.EndHour = reader.GetString(3);
                        workHour.EmployeeId = (int)reader["EmployeeID"];
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("WorkHourları getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return workHour;
        }

        public List<WorkHour> GetAll()
        {
            /*             
                create proc sp_GetAllWorkHour
                as
                select ID,Name,StartHour,EndHour,EmployeeID from WorkHour    
                                              
             */
            List<WorkHour> workHourList = new List<WorkHour>();
            _command.CommandText = "sp_GetAllWorkHour";
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
                        WorkHour workHour = new WorkHour();
                        workHour.ID = (int)reader["ID"];
                        workHour.Name = reader.GetString(1);
                        workHour.StartHour = reader.GetString(2);
                        workHour.EndHour = reader.GetString(3);
                        workHour.EmployeeId = (int)reader["EmployeeID"];

                        workHourList.Add(workHour);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("WorkHour listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return workHourList;
        }

        public int Insert(WorkHour item)
        {
            int affectedRows = 0;
            /*  
                create proc sp_AddWorkHour
                @name nvarchar(50),
                @startHour nchar(5),
                @endHour nchar(5),
                @employeeID int
                as
                begin
                Insert into WorkHour(Name,StartHour,EndHour,EmployeeID) values(@name,@startHour,@endHour,@employeeID)
                end             
             */
            _command.CommandText = "sp_AddWorkHour";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@startHour", item.StartHour);
            _command.Parameters.AddWithValue("@endHour", item.EndHour);
            _command.Parameters.AddWithValue("@employeeID", item.EmployeeId);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("WorkHour Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(WorkHour item)
        {
            /*
               create proc sp_UpdateWorkHour
               @id int,
               @name nvarchar(50),
               @startHour nchar(5),
               @endHour nchar(5),
               @employeeID int
               as
               begin
               Update WorkHour set Name=@name,StartHour= @startHour,EndHour=@endHour,EmployeeID=@employeeID where ID=@id
               end
           */

            int affectedRows = 0;
            _command.CommandText = "sp_UpdateWorkHour";
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@startHour", item.StartHour);
            _command.Parameters.AddWithValue("@endHour", item.EndHour);
            _command.Parameters.AddWithValue("@employeeID", item.EmployeeId);
            _command.Parameters.AddWithValue("@id", item.ID);


            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("WorkHour Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Delete(WorkHour item)
        {
            /*
               create proc sp_DeleteWorkHour
               @id int
               as
               begin
               Delete from WorkHour where ID=@id
               end
           */


            int affectedRows = 0;

            _command.CommandText = "sp_DeleteWorkHour";
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
                throw new Exception("WorkHour Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

    }
}
