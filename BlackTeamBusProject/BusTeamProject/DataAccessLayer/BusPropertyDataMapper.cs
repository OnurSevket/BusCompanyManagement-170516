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
  public  class BusPropertyDataMapper :IDataMapper<BusProperty, int>
    {
        SqlCommand _sqlComm;
        public BusPropertyDataMapper()
        {
            _sqlComm = SqlHelper.createSqlCommand();
        }

        public int Delete(BusProperty item)
        {
            /*
             alter proc sp_DeleteBusProperty
	            @Id int
	            as
	            begin
	            delete from BusProperty where BusProperty.ID = @Id
	            end
	            go
             */
            int affectedRows = 0;
            _sqlComm.CommandText = "sp_DeleteBusProperty";
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

                throw new Exception("BusProperty Tablosunda Silinecek Kayıt Bulunamadı" + ex.Message); //todo:
            }
            finally
            {

                _sqlComm.Connection.Close();
            }

            return affectedRows = 0;
        }

        public BusProperty Get(int key)
        {
            /*
              alter proc sp_GetBusPropertyById
                @Id int
                as
                begin
                select BusProperty.ID,BusProperty.Name from BusProperty where ID = @Id
                end
             */
            _sqlComm.CommandText = "sp_GetBusPropertyById";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@Id", key);


            try
            {
                BusProperty busProperty = null;
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                }
                SqlDataReader reader = _sqlComm.ExecuteReader();
                if (reader.HasRows)  
                {
                    while (reader.Read()) 
                    {
                        busProperty = new BusProperty();
                        busProperty.ID = Convert.ToInt32(reader["ID"]);
                        busProperty.Name = reader["Name"].ToString();
                    }
                }
                return busProperty;
            }
            catch (Exception ex)
            {

                throw new Exception("Bu BusProperty ye ait bir kayıt bulunamadı"+ex.Message);

            }
            finally
            {
                _sqlComm.Connection.Close();
            }
        
            
            
        }

        public List<BusProperty> GetAll()
        {
            /*
              alter proc sp_GetAllBusProperty
             as
	            begin
	            select *from BusProperty
	            end
             */
            _sqlComm.CommandText = "sp_GetAllBusProperty";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            try
            {
                List<BusProperty> busPropertyList = new List<BusProperty>();
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                    _sqlComm.Parameters.Clear();

                    SqlDataReader reader = _sqlComm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            BusProperty busProperty = new BusProperty();
                            busProperty.ID = Convert.ToInt32(reader["ID"]);
                            busProperty.Name = reader["Name"].ToString();

                            busPropertyList.Add(busProperty);
                        }
                    }
                }
                return busPropertyList;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlComm.Connection.Close();
            }
        }

        public int Insert(BusProperty item)
        {
            /*
              alter proc sp_AddBusProperty   --Insert Bus
      
		          @name nvarchar(50)
                as 
                begin
                Insert BusProperty(Name) values (@name)  
                end
             */
            _sqlComm.CommandText = "sp_AddBusProperty";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@name",item.Name);

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

                throw new Exception("BusProperty eklenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(BusProperty item)
        {
            /*
             alter proc sp_UpdateBusProperty 
	        @name nvarchar(50),
	        @Id int
		        as 
		        begin
		        update BusProperty  set BusProperty.Name = @name where BusProperty .ID = @Id 
		        end
             */
            _sqlComm.Parameters.Clear();
            _sqlComm.CommandText = "sp_UpdateBusProperty";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.AddWithValue("@name",item.Name);
            _sqlComm.Parameters.AddWithValue("@Id",item.ID);

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

                throw new Exception("BusProperty güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;


        }
    }
}
