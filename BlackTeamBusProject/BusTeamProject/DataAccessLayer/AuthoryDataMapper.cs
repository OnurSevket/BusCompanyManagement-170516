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
  public  class AuthoryDataMapper : IDataMapper<Authory, int>
    {
        SqlCommand _sqlComm;  // baglantı tanımladık
        public AuthoryDataMapper()
        {
            _sqlComm = SqlHelper.createSqlCommand(); // bagladık 
        }

        public int Delete(Authory item) // authory dönüştüpi olucak
        {
            /*
              alter proc sp_DeleteAuthory
	            @Id int
	            as
	            begin
	            delete from Authory where Authory.ID = @Id
	            end
	            go
             */
            _sqlComm.CommandText = "sp_DeleteAuthory";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
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

                throw new Exception("Author Tablosunda Silinecek Kayıt Bulunamadı" + ex.Message); //todo:
            }
            finally
            {
                _sqlComm.Connection.Close();
            }


            return affectedRows = 0;
        }

        public Authory Get(int key)
        {
            /*
              create proc sp_GetAuthoryById
                @Id int
                as
                begin
                select Authory.ID, Authory.AuthoryName from Authory where ID = @Id
                end
             */
            
          _sqlComm.CommandText = "sp_GetAuthoryById";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@Id", key);

            try
            {
                Authory authory = null;
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                }
                SqlDataReader reader = _sqlComm.ExecuteReader();
                if (reader.HasRows)  // satr oldukça
                {
                    while (reader.Read())  // okumaya devam et
                    {
                       authory = new Authory();
                        authory.ID = Convert.ToInt32(reader["ID"]);
                        authory.AuthoryName = reader["AuthoryName"].ToString();
                    }
                }
                return authory;

            }
            catch (Exception ex)
            {

                throw new Exception("Authory getirken  bir sorun oluştu " + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }
        }

        public List<Authory> GetAll()
        {
            /*
              create proc sp_GetAllAuthory
                as
                  begin
                  select Authory.ID,AuthoryName  from Authory
                  end
             */

            _sqlComm.CommandText = "sp_GetAllAuthory";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();

            try
            {
                List<Authory> authoryList = new List<Authory>();
                if (_sqlComm.Connection.State == ConnectionState.Closed)
                {
                    _sqlComm.Connection.Open();
                    SqlDataReader reader = _sqlComm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Authory authory = new Authory();
                            authory.ID = Convert.ToInt32(reader["ID"]);
                            authory.AuthoryName = reader["AuthoryName"].ToString();


                            authoryList.Add(authory); // list e at 
                        }
                    }
                }
                return authoryList;
            }
            catch (Exception ex)
            {

                throw new Exception("Authory tablosunda kayıt bulunamadı" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            
           }

        public int Insert(Authory item)
        {
            /*
             create proc sp_AddAuthory     --Insert Bus
              @Id int,
			  @authoryName nvarchar(50)
	                as 
	                begin
	                Insert Authory(AuthoryName,ID) values (@authoryName,@Id)
	                end
             */
            _sqlComm.CommandText = "sp_AddAuthory";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@authoryName",item.AuthoryName);

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

                throw new Exception("Authory eklenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;  //dönüş tipimiz

        }

        public int Update(Authory item)
        {
            /*
             create proc sp_UpdateAuthory
	            @authoryName nvarchar(50),
                @id int
		            as 
		            begin
		            update Authory set AuthoryName = @authoryName where ID=@id;
		            end
             */
            _sqlComm.CommandText = "sp_UpdateAuthory";
            _sqlComm.CommandType = CommandType.StoredProcedure;
            _sqlComm.Parameters.Clear();
            _sqlComm.Parameters.AddWithValue("@authoryName",item.AuthoryName);
            _sqlComm.Parameters.AddWithValue("@id", item.ID);

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

                throw new Exception("Authory güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _sqlComm.Connection.Close();
            }

            return affectedRows;

        }

        
    }
}
