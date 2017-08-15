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
    public class RoadExpenseDataMapper : IDataMapper<RoadExpense, int>
    {
        SqlCommand _command;

        public RoadExpenseDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public RoadExpense Get(int key)
        {
            /*             
                create proc sp_GetRoadExpenseByID
                @id int
                as
                select ID,ExpenseName,BusID,TotalPrice from RoadExpense where ID=@id                        
             */
            _command.CommandText = "sp_GetRoadExpenseByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);
            RoadExpense roadExpense = new RoadExpense();
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

                        roadExpense.ID = (int)reader[0];
                        roadExpense.ExpenseName = Convert.ToString(reader[1]);
                        roadExpense.BusID = (int)reader[2];
                        roadExpense.TotalPrice = (decimal)reader[3];
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("RoadExpenseleri getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return roadExpense;
        }

        public List<RoadExpense> GetAll()
        {
            /*             
                create proc sp_GetAllRoadExpense
                as
                select ID,ExpenseName,BusID,TotalPrice from RoadExpense                       
             */

            List<RoadExpense> roadExpenseList = new List<RoadExpense>();
            _command.CommandText = "sp_GetAllRoadExpense";
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
                        RoadExpense roadExpense = new RoadExpense();
                        roadExpense.ID = (int)reader[0];
                        roadExpense.ExpenseName = Convert.ToString(reader[1]);
                        roadExpense.BusID = (int)reader[2];
                        roadExpense.TotalPrice = (decimal)reader[3];

                        roadExpenseList.Add(roadExpense);
                    }
                }
              
            }
            catch (Exception ex)
            {

                throw new Exception("RoadExpense listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return roadExpenseList;
        }

        public int Insert(RoadExpense item)
        {
            int affectedRows = 0;
            /*  
                create proc sp_InsertRoadExpense
                @expenseName nvarchar(50),
                @busId int,
                @totalPrice decimal
                as
                begin
                Insert into RoadExpense(ExpenseName,BusID,TotalPrice) values(@expenseName,@busId,@totalPrice)
                end             
             */
            _command.CommandText = "sp_InsertRoadExpense";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@expenseName", item.ExpenseName);
            _command.Parameters.AddWithValue("@busId", item.BusID);
            _command.Parameters.AddWithValue("@totalPrice", item.TotalPrice);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("RoadExpense Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(RoadExpense item)
        {
            /*
                create proc sp_UpdateRoadExpense
                @id int,
                @expenseName nvarchar(50),
                @busId int,
                @totalPrice decimal
                as
                begin
                Update RoadExpense set ExpenseName=@expenseName,BusID=@busId,TotalPrice=@totalPrice where ID=@id
                end
            */

            int affectedRows = 0;
            _command.CommandText = "sp_UpdateRoadExpense";
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@expenseName", item.ExpenseName);
            _command.Parameters.AddWithValue("@busId", item.BusID);
            _command.Parameters.AddWithValue("@totalPrice", item.TotalPrice);
            _command.Parameters.AddWithValue("@id", item.ID);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("RoadExpense Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Delete(RoadExpense item)
        {
            /*
                create proc sp_DeleteRoadExpense
                @id int
                as
                begin
                Delete from RoadExpense where ID=@id
                end
           */


            int affectedRows = 0;

            _command.CommandText = "sp_DeleteRoadExpense";
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
                throw new Exception("RoadExpense Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }


    }
}
