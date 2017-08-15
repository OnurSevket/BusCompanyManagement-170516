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
  public  class LoginDataMapper :IDataMapper<Login,int>
    {
        SqlCommand _command;
        public LoginDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }


        public Login Get(int key)
        {
            /*
              create procedure sp_GetLoginByID
                @id int
                as
                select ID,Name,Password from Login where ID=@id
             */
            _command.CommandText = "sp_GetLoginByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);

            try
            {
                Login login = null;
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        login = new Login();
                        login.ID = (int)reader[0];
                        login.Name = reader[1].ToString();
                        login.Password = reader[2].ToString();
                    }
                return login;

            }
            catch (Exception ex)
            {
                throw new Exception("Login getirilirken  bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }

        public List<Login> GetAll()
        {
            /*
              create procedure sp_GetAllLogin
                as
                select ID,Name,Password from Login
             */
            _command.CommandText = "sp_GetAllLogin";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();

            try
            {
                List<Login> loginList = new List<Login>();
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        Login login = new Login();
                        login.ID = (int)reader[0];
                        login.Name = reader[1].ToString();
                        login.Password = reader[2].ToString();
                        loginList.Add(login);
                    }
               
                return loginList;

            }
            catch (Exception ex)
            {
                throw new Exception("Loginleri getirirken bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }

        public int Insert(Login item)
        {
            /*
             	 create procedure sp_InsertLogin
                @name nvarchar(50),
                @password nvarchar(50)
                as
                begin
                    insert into Login(Name,Password)values(@name,@password)
                end
             */
            _command.CommandText = "sp_InsertAddress";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@password", item.Password);
            int affectedRow = 0;
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRow = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Login eklerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Update(Login item)
        {
            /*
             create procedure sp_UpdateLogin
               @name nvarchar(50),
               @password nvarchar(50),
               @id int
               as
               begin
                  update Login set Name=@name,Password=@password where ID=@id
               end

             */
            _command.CommandText = "sp_UpdateLogin";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@password", item.Password);
            _command.Parameters.AddWithValue("@id", item.ID);
            int affectedRow = 0;
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRow = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Login güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Delete(Login item)
        {
            /*
             create procedure sp_DeleteLogin
              @id int
              as
              begin
               delete from Login where ID=@id
              end
            */
            _command.CommandText = "sp_DeleteLogin";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", item.ID);
            int affectedRow = 0;
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRow = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Login silerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }
    }
}
