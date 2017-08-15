using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;


namespace DataAccessLayer
{
   public class BusDataMapper : IDataMapper<Bus, int>
    {
        SqlCommand _sqlComm;

        public BusDataMapper()
        {
            _sqlComm = SqlHelper.createSqlCommand();
        }

        public int Delete(Bus item)
        {
            /*
	            create proc sp_DeleteBus
	            @Id int
	            as
	            begin
	             delete from Bus where Bus.ID = @Id
	            end
              */
            int affectedRows = 0;
            _sqlComm.CommandText = "sp_DeleteBus";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear(); 
            _sqlComm.Parameters.AddWithValue("@Id",item.ID);

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

                throw new Exception("Bus Tablosunda Silinecek Kayıt Bulunamadı"+ex.Message) ; 
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows = 0 ;
        }

        public Bus Get(int key)
        {
            /*
             create proc sp_GetBusById
                @Id int
                as
                begin
                select Bus.ID,Bus.Brand, Bus.BusTypeID, Bus.Model, Bus.Plate, Bus.Year from Bus where ID = @Id
                end
             */
            _sqlComm.CommandText = "sp_GetBusById";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@Id",key);

            try
            {
                Bus bus = null;
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                }
                    SqlDataReader reader = _sqlComm.ExecuteReader();
                    if (reader.HasRows) 
                    {
                        while (reader.Read())
                        {
                            bus = new Bus();
                            bus.ID = Convert.ToInt32(reader["ID"]);
                            bus.Model = reader["Model"].ToString();
                            bus.Year = Convert.ToDateTime(reader["Year"]);
                            bus.BusTypeID = Convert.ToInt32(reader["BusTypeID"]);
                            bus.Brand = reader["Brand"].ToString();
                            bus.Plate = reader["Plate"].ToString();
                        }
                    }
                    
                    return bus;
                
            }
            catch (Exception ex)
            {

                throw new Exception ("BUS getirken  bir sorun oluştu " + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            
        }

        public List<Bus> GetAll()
        {
            // todo:
            /*
             create proc sp_GetAllBus
                as
                begin
                select bus.ID,Bus.Brand,Bus.BusTypeID,Bus.Model, Bus.Plate, Bus.Year from Bus
                end

             */

            _sqlComm.CommandText = "sp_GetAllBus";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            // bus tipin list tut 
            try
            {
                List<Bus> busList = new List<Bus>();
                if(_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                    SqlDataReader reader = _sqlComm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           
                           Bus bus = new Bus();
                            bus.ID = Convert.ToInt32(reader["ID"]);
                            bus.Model = reader["Model"].ToString();
                            bus.Year = Convert.ToDateTime(reader["Year"]);
                            bus.BusTypeID = Convert.ToInt32(reader["BusTypeID"]);
                            bus.Brand = reader["Brand"].ToString();
                            bus.Plate = reader["Plate"].ToString();

                            busList.Add(bus); 
                        }
                    }
                    
                }
                return busList; 
            }
            catch (Exception ex)
            {

                throw new Exception("Bus tablosunda kayı bulunamadı"+ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }
        }

        public int Insert(Bus item)
        {
            /*
            alter proc sp_AddBus     --Insert Bus
                @brand nvarchar(50),
                @model nvarchar(50),
                @year datetime,
                @busType int,
                @plate nchar(10)
	                as 
	                begin
	                Insert Bus(Brand,Model,Year,BusTypeID,Plate) values (@brand,@model,@year,@busType,@plate)
	                end
             */


            _sqlComm.CommandText = "sp_AddBus";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@brand",item.Brand);
            _sqlComm.Parameters.AddWithValue("@model", item.Model);
            _sqlComm.Parameters.AddWithValue("@year",item.Year);
            _sqlComm.Parameters.AddWithValue("@busType",item.BusTypeID);
            _sqlComm.Parameters.AddWithValue("@plate",item.Plate);


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

                throw new Exception("Bus eklenirken bir sorun oluştu"+ex.Message) ;
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(Bus item)
        {
            /*
             create proc sp_UpdateBus
	            @brand nvarchar(50),
	            @model nvarchar(50),
	            @year datetime,
	            @busType int,
	            @plate nchar(10),
                @id int
	            as
	            begin
	            update Bus set Brand = @brand, Model=@model,Year = @year, BusTypeID = @busType, Plate = @plate where ID=@id
	            end
             */

            _sqlComm.CommandText = "sp_UpdateBus";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@brand", item.Brand);
            _sqlComm.Parameters.AddWithValue("@model", item.Model);
            _sqlComm.Parameters.AddWithValue("@year", item.Year);
            _sqlComm.Parameters.AddWithValue("@busType", item.BusTypeID);
            _sqlComm.Parameters.AddWithValue("@plate", item.Plate);
            _sqlComm.Parameters.AddWithValue("@id", item.ID);


            int affectedRows = 0; // etkilenen satır sayısı

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

                throw new Exception("Bus güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;
        }
    }
}
