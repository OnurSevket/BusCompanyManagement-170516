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
    public class BusSeatDataMapper : IDataMapper<BusSeat, int>
    {
        SqlCommand _sqlComm;

        public BusSeatDataMapper()
        {
            _sqlComm = SqlHelper.createSqlCommand();
        }

        public CommandType CommanType { get; private set; }

        public int Delete(BusSeat item)
        {
            /*
             alter proc sp_DeleteBusSeat
	            @Id int
	            as
	            begin
	            delete from BusSeat where BusSeat.ID = @Id
	            end
	            go
             */
            int affectedRows = 0;
            _sqlComm.CommandText = "sp_DeleteBusSeat";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@Id",item.ID);

            try
            {
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                    _sqlComm.Connection.Open();

                affectedRows = _sqlComm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception ("BusSeat tablosunda Silinecek ıd bulunamadı"+ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }
            return affectedRows = 0;
        }

        public BusSeat Get(int key)
        {
            /*
             alter proc sp_GetBusSeat
                @Id int
                as
                begin
                select * from BusSeat where ID = @Id
                end
              */
            _sqlComm.CommandText = "sp_GetBusSeat";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@Id",key);

            try
            {
                BusSeat busSeat = new BusSeat();
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                    _sqlComm.Connection.Open();
                SqlDataReader reader = _sqlComm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        busSeat = new BusSeat();
                        busSeat.ID = Convert.ToInt32(reader["ID"]);
                        busSeat.BusID = Convert.ToInt32(reader["BusID"]);
                        busSeat.BusTypeID = Convert.ToInt32(reader["BusTypeID"]);
                        busSeat.IsWindow = Convert.ToBoolean(reader["IsWindow"]);
                        busSeat.SeatNumber = Convert.ToInt32(reader["SeatNumber"]);

                    }
                }
                return busSeat;
            }
            catch (Exception)
            {

                throw new Exception("Bu BusSeat a ait bir Kayıt Yok");
            }
            finally
            {
                _sqlComm.Connection.Close();
            }
        }

        public List<BusSeat> GetAll()
        {
            /*
             create proc sp_GetAllBusSeat
                as
                begin
                select * from BusSeat
                end
             */
            _sqlComm.CommandText = "sp_GetAllBusSeat";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();

            try
            {
                List<BusSeat> busSeatList = new List<BusSeat>();
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                    _sqlComm.Connection.Open();

                SqlDataReader reader = _sqlComm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BusSeat busSeat = new BusSeat();
                        busSeat.ID = Convert.ToInt32(reader["ID"]);
                        busSeat.BusID = Convert.ToInt32(reader["BusID"]);
                        busSeat.BusTypeID = Convert.ToInt32(reader["BusTypeID"]);
                        busSeat.IsWindow = Convert.ToBoolean(reader["IsWindow"]);
                        busSeat.SeatNumber = Convert.ToInt32(reader["SeatNumber"]);

                        busSeatList.Add(busSeat);
                    }
                }

                return busSeatList;
                
            }
            catch (Exception)
            {

                throw new Exception("BusSeat tablosunda kayıt Bulunamadı");
            }
            finally
            {
                _sqlComm.Connection.Close();
            }
        }

        public int Insert(BusSeat item)
        {
            /*
             create proc sp_AddBusSeat
               @busId int,
               @BusTypeId int,
               @seatNumber int,
               @isWindow bit
             as 
             begin
             Insert BusSeat(BusID,BusTypeID,SeatNumber,IsWindow) values (@busId,@BusTypeId,@seatNumber,@isWindow) 
             end
             */

            _sqlComm.CommandText = "sp_AddBusSeat";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@busId", item.BusID);
            _sqlComm.Parameters.AddWithValue("@BusTypeId",item.BusTypeID);
            _sqlComm.Parameters.AddWithValue("@isWindow", item.IsWindow);
            _sqlComm.Parameters.AddWithValue("@seatNumber", item.SeatNumber);

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

                throw new Exception("BusSeat eklenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(BusSeat item)
        {
            /*
             create proc sp_UpdateBusSeat
              @busId int,
              @busTypeId int,
              @seatNumber int,
              @isWidow bit,
              @Id int
                  as 
                  begin
                  update BusSeat set BusID=@busId,BusTypeID=@busTypeId,IsWindow = @isWidow, SeatNumber=@seatNumber where BusSeat.ID = @Id 
                  end
             */

            _sqlComm.CommandText = "sp_UpdateBusSeat";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@busId",item.BusID);
            _sqlComm.Parameters.AddWithValue("@busTypeId",item.BusTypeID);
            _sqlComm.Parameters.AddWithValue("@isWidow", item.IsWindow);
            _sqlComm.Parameters.AddWithValue("@seatNumber", item.SeatNumber);
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

                throw new Exception("BusSeat güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;

        }
    }
}
