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
 public   class BusTypeDataMapper : IDataMapper<BusType, int>
    {
        SqlCommand _sqlComm = new SqlCommand();
        public BusTypeDataMapper()
        {
            _sqlComm = SqlHelper.createSqlCommand();
        }

        public int Delete(BusType item)
        {
            int affectedRows = 0;
            //Ara tablodaki kayıtların da silinmesi işleminin yapılması
            _sqlComm.Parameters.Clear();
            /*
             create procedure sp_DeleteBusProperyBusTypeById
               @busTypeID int
               as
               begin
               	delete from BusPropertyBusType where BusTypeID=@busTypeID 
               end
             */
            _sqlComm.CommandText = "sp_DeleteBusProperyBusTypeById";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.Add("@busTypeID", item.ID);
            try
            {
                if (_sqlComm.Connection.State == System.Data.ConnectionState.Closed)
                    _sqlComm.Connection.Open();
                affectedRows = _sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("BusType Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }


            /*
             alter proc sp_DeleteBusType
	            @Id int
	            as
	            begin
	            delete from BusType where BusType.ID = @Id
	            end
	            go
             */


            
            _sqlComm.CommandText = "sp_DeleteBusType";
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

                throw new Exception("BUstype Tablosunda Silinecek Kayıt Bulunamadı" + ex.Message); //todo:
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            



            return affectedRows = 0;
        }

        public BusType Get(int key)
        {
            /*
            alter proc sp_GetBusTypeById
                @Id int
                as
                begin
                select * from BusType where ID = @Id
                end
             */
            _sqlComm.CommandText = "sp_GetBusTypeById";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@Id",key);
            BusType busType = new BusType();
            try
            {
                
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                    _sqlComm.Connection.Open();
                SqlDataReader reader = _sqlComm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        busType = new BusType();
                        busType.ID = Convert.ToInt32(reader["ID"]);
                        busType.Name = reader["Name"].ToString();
                        busType.SeatCount = Convert.ToInt32(reader["SeatCount"]);
                        busType.BackDoorIndex = Convert.ToInt32(reader["BackDoorIndex"]);
                    }
                }
                else
                    throw new Exception("Bu Bus tipinine ait kayıt bulunamadı !!");




                
            }
            catch (Exception ex)
            {

                throw new Exception ("Bu Bus tipinine ait kayt bulunamadı !!"+ex.Message);
            }

            finally
            {
                _sqlComm.Connection.Close();
            }

            /*
                 
                begin try
               drop procedure sp_GetBusProperyBusTypeByID
               end try
               begin catch 
               end catch
               go
               create procedure sp_GetBusProperyBusTypeByID
                @busTypeID int
                as
                begin 
                    select BusTypeID,BusPropertyID from  BusPropertyBusType  where BusTypeID=@busTypeID
                end
 
             */
            _sqlComm.CommandText = "sp_GetBusProperyBusTypeByID";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@busTypeID", key);

            try
            {
                
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                    _sqlComm.Connection.Open();
                SqlDataReader reader = _sqlComm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        BusPropertyDataMapper busPropertyDataMapper = new BusPropertyDataMapper();
                        int busPropertyID=(int)reader[1];
                        BusProperty busPropery = busPropertyDataMapper.Get(busPropertyID);
                        busType.BusPropertList.Add(busPropery);
                    }
                }




                return busType;
            }
            catch (Exception ex)
            {

                throw new Exception("Bu Bus tipinine ait kayt bulunamadı !!" + ex.Message);
            }

            finally
            {
                _sqlComm.Connection.Close();
            }

        }

        public List<BusType> GetAll()
        {
            /*
              alter proc sp_GetAllBusType
                as
	                begin
	                select * from BusType
	                end
             */

            _sqlComm.CommandText = "sp_GetAllBusType";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            try
            {
                List<BusType> usebusTypeList = new List<BusType>();
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                    _sqlComm.Connection.Open();

                SqlDataReader reader = _sqlComm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BusType usebusType = new BusType();
                        usebusType.ID = Convert.ToInt32(reader["ID"]);
                        usebusType.Name = reader["Name"].ToString();
                        usebusType.SeatCount = Convert.ToInt32(reader["SeatCount"]);
                        usebusType.BackDoorIndex = Convert.ToInt32(reader["BackDoorIndex"]);

                        usebusTypeList.Add(usebusType);
                    }
                }

                return usebusTypeList;
            }
            catch (Exception )
            {

                throw new Exception("BusType Tablosunda kayıt bulunamadı");
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

        }
        int lastIndex;
        public int Insert(BusType item)
        {
            /*
              alter proc sp_AddBusType 
		@name nvarchar(50),
		@backDoorIndex int,
		@seatCount int
        as 
        begin
        Insert BusType(BackDoorIndex,Name,SeatCount) values (@backDoorIndex,@name,@seatCount) 
        SELECT SCOPE_IDENTITY()
        end
             */

            _sqlComm.CommandText = "sp_AddBusType";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@name",item.Name);
            _sqlComm.Parameters.AddWithValue("@seatCount", item.SeatCount);
            _sqlComm.Parameters.AddWithValue("@backDoorIndex",item.BackDoorIndex);

            int affectedRows = 0; 

            try
            {
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                }
                
                Object lastIndexObje = _sqlComm.ExecuteScalar();
                lastIndex = int.Parse(lastIndexObje.ToString());
            }
            catch (Exception ex)
            {

                throw new Exception("BusType eklenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }


            /// Ara tabloya insert işlemi yapılması için yapıldı 

            foreach (BusProperty _property in item.BusPropertList)
            {
                _sqlComm.Parameters.Clear();

                /*
                 create procedure sp_AddBusProperyBusType
                    @busPropertyID int,
                    @busTypeID int
                    as
                    begin 
                    	insert into BusPropertyBusType(BusTypeID,BusPropertyID) values(@busTypeID,@busPropertyID)
                    end
                 */
                _sqlComm.CommandText = "sp_AddBusProperyBusType";
                _sqlComm.CommandType = CommandType.StoredProcedure;
                _sqlComm.Parameters.Clear();
                _sqlComm.Parameters.AddWithValue("@busPropertyID", _property.ID);
                _sqlComm.Parameters.AddWithValue("@busTypeID", lastIndex);
                try
                {
                    if (_sqlComm.Connection.State == System.Data.ConnectionState.Closed)
                        _sqlComm.Connection.Open();

                    affectedRows = _sqlComm.ExecuteNonQuery();
                    if (affectedRows > 0)
                    { }
                    else
                        throw new Exception("Bus property  eklenmedi");
                }
                catch (Exception ex)
                {
                    throw new Exception("BusTypeDataMapper: Bus Type eklerken hata oluştu :" + ex.Message);
                }
                finally
                {
                    _sqlComm.Connection.Close();
                }
            }

            return affectedRows;
        }

        public int Update(BusType item)
        {
            //Ara tablodaki kayıtları silme ve ekleme işlemleri yapıyor işlemi yapıyor

            /*
             create procedure sp_DeleteBusProperyBusTypeById
               @busTypeID int
               as
               begin
                delete from BusPropertyBusType where BusTypeID=@busTypeID 
               end
             */
            int affectedRows = 0; 
            _sqlComm.Parameters.Clear();
            _sqlComm.CommandText = "sp_DeleteBusProperyBusTypeById";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.Add("@busTypeID", item.ID);
            try
            {
                if (_sqlComm.Connection.State == System.Data.ConnectionState.Closed)
                    _sqlComm.Connection.Open();
                affectedRows = _sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("BusType Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            //Ara tabloya güncel değerler kaydediliyor
            foreach (BusProperty _property in item.BusPropertList)
            {
                _sqlComm.Parameters.Clear();

                /*
                 create procedure sp_AddBusProperyBusType
                    @busPropertyID int,
                    @busTypeID int
                    as
                    begin 
                    	insert into BusPropertyBusType(BusTypeID,BusPropertyID) values(@busTypeID,@busPropertyID)
                    end
                 */
                _sqlComm.CommandText = "sp_AddBusProperyBusType";
                _sqlComm.CommandType = CommandType.StoredProcedure;
                _sqlComm.Parameters.Clear();
                _sqlComm.Parameters.AddWithValue("@busPropertyID", _property.ID);
                _sqlComm.Parameters.AddWithValue("@busTypeID", item.ID);
                try
                {
                    if (_sqlComm.Connection.State == System.Data.ConnectionState.Closed)
                        _sqlComm.Connection.Open();

                    affectedRows = _sqlComm.ExecuteNonQuery();
                    if (affectedRows > 0)
                    { }
                    else
                        throw new Exception("Bus property  eklenmedi");
                }
                catch (Exception ex)
                {
                    throw new Exception("BusTypeDataMapper: Bus Type eklerken hata oluştu :" + ex.Message);
                }
                finally
                {
                    _sqlComm.Connection.Close();
                }
            }


            /*
             alter proc sp_UpdateBusType
	            @name nvarchar(50) ,
	            @Id int,
	            @seatCount int,
	            @backDoorIndex int
		            as 
		            begin
		            update BusType set BackDoorIndex = @backDoorIndex, Name=@name, SeatCount = @seatCount where BusType.ID = @Id 
		            end
             */

            _sqlComm.CommandText = "sp_UpdateBusType";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@name", item.Name);
            _sqlComm.Parameters.AddWithValue("@seatCount", item.SeatCount);
            _sqlComm.Parameters.AddWithValue("@backDoorIndex", item.BackDoorIndex);
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

                throw new Exception("BusType güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            


            return affectedRows;
           
        }
    }
}
