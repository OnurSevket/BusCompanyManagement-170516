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
  public  class BusEmployeeDataMapper : IDataMapper<BusEmployee, int>
    {
        SqlCommand _sqlComm;

        public BusEmployeeDataMapper()
        {
            _sqlComm = SqlHelper.createSqlCommand();
        }

        public int Delete(BusEmployee item)
        {
            /*
              create proc sp_DeleteBusEmployee
	            @Id int
	            as
	            begin
	            delete from BusEmployee where BusEmployee.ID = @Id
	            end
	            go
             */
            int affectedRows = 0;
            _sqlComm.CommandText = "sp_DeleteBusEmployee";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@Id", item.ID);

            try
            {
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                }
                affectedRows = _sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("BusEmployee Tablosunda Silinecek Kayıt Bulunamadı" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows = 0;

        }

        public BusEmployee Get(int key)
        {
            /*
           alter proc sp_GetBusEmployee
          @Id int
          as
          begin
          select ID, CreateDate,BusID,EmployeeID,RouteMapID from BusEmployee where ID = @Id
          end
             */
            _sqlComm.CommandText = "sp_GetBusEmployee";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@Id", key);

            try
            {
                BusEmployee busEmployee = null;
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                }
                SqlDataReader reader = _sqlComm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        busEmployee = new BusEmployee();
                        busEmployee.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                        busEmployee.RouteMapID = Convert.ToInt32(reader["RouteMapID"]);
                        busEmployee.ID = Convert.ToInt32(reader["ID"]);
                        busEmployee.Employee = Convert.ToInt32(reader["EmployeeID"]);
                        busEmployee.BusID = Convert.ToInt32(reader["BusID"]);

                    }
                }
                return busEmployee;

            }
            catch (Exception ex)
            {

                throw new Exception("busEmployee getirken  bir sorun oluştu " + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }
            throw new NotImplementedException();
        }

        public List<BusEmployee> GetAll()
        {
            /*
             alter proc sp_GetAllBusEmployee
                as
	                begin
	                select ID, CreateDate,BusID,EmployeeID,RouteMapID from BusEmployee 
	                end
             */
            _sqlComm.CommandText = "sp_GetAllBusEmployee";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();

            try
            {
                List<BusEmployee> busEmployeeList = new List<BusEmployee>();
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                    SqlDataReader reader = _sqlComm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            BusEmployee busEmployee = new BusEmployee();
                            busEmployee.ID = Convert.ToInt32(reader["ID"]);
                            busEmployee.BusID = Convert.ToInt32(reader["BusID"]);
                            busEmployee.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                            busEmployee.Employee = Convert.ToInt32 (reader["EmployeeID"]);
                            busEmployee.RouteMapID = Convert.ToInt32(reader["RouteMapID"]);

                            busEmployeeList.Add(busEmployee);
                        }
                    }

                }
                return busEmployeeList;
            }
            catch (Exception ex)
            {

                throw new Exception("busEmployeeList tablosunda kayı bulunamadı" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }
        }

        public int Insert(BusEmployee item)
        {
            /*

		
            alter proc sp_AddBusEmployee 
           
           @employeeId int,
           @createDate datetime,
           @routeMapId int,
		   @busId int
            as 
            begin
            Insert into BusEmployee(BusID,EmployeeID,CreateDate,RouteMapID) values (@busId,@employeeId,@createDate,@routeMapId) 
            end
             */
            _sqlComm.CommandText = "sp_AddBusEmployee";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@busId", item.BusID);
            _sqlComm.Parameters.AddWithValue("@employeeId", item.Employee);
            _sqlComm.Parameters.AddWithValue("@createDate", item.CreateDate);
            _sqlComm.Parameters.AddWithValue("@routeMapId", item.RouteMapID);

            int affectedRows = 0; 

            try
            {
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                }
                affectedRows = _sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("BusEmployee eklenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;

        }

        public int Update(BusEmployee item)
        {
            /*

                create proc sp_UpdateBusEmployee
                @busId int,
               	@employeeId int,
               	@createDate datetime,
               	@routeMapID int,
               	@Id int
               	    as 
               	    begin
               	    update BusEmployee set BusID=@busId,EmployeeID=@employeeId,CreateDate = @createDate,RouteMapID=@routeMapID where BusEmployee.ID = @Id 
               	    end
             */

            _sqlComm.CommandText = "sp_UpdateBusEmployee";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@busId",item.BusID);
            _sqlComm.Parameters.AddWithValue("@employeeId",item.Employee);
            _sqlComm.Parameters.AddWithValue("@createDate",item.CreateDate);
            _sqlComm.Parameters.AddWithValue("@routeMapID", item.RouteMapID);
            _sqlComm.Parameters.AddWithValue("@Id", item.ID);
            
            int affectedRows = 0; 

            try
            {
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                }
                affectedRows = _sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("BusEmployee güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;
        }
    }
}
