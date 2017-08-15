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
    public class LoginPassengerDataMapper : IDataMapper<LoginPassenger, int>
    {
        SqlCommand _command;
        public LoginPassengerDataMapper()
        {
            _command=SqlHelper.createSqlCommand(); 
        }

        public LoginPassenger Get(int key)
        {
            throw new NotImplementedException();
        }

        public List<LoginPassenger> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(LoginPassenger item)
        {
            throw new NotImplementedException();
        }

        public int Update(LoginPassenger item)
        {
            throw new NotImplementedException();
        }
        public int Delete(LoginPassenger item)
        {
            throw new NotImplementedException();
        }
        
        public int GetIdCorrectLogin(LoginPassenger item)
        {
            /*
             * 
             
                create proc sp_PassangerLogin
                @name nvarchar(50),
                @password nvarchar(50)
                as
                select
                ID
                from
                LoginPassenger where Name='@name' and Password='@password'
             
             
             */

            _command.CommandText = "sp_PassangerLogin";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@password",item.Password);
            LoginPassenger loginPassanger = new LoginPassenger();
            try
            {

                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                //int reader = _command.ExecuteScalar();
                //int loginID = Convert.ToInt32(reader[0]);
                //return loginID; 
                //TODO: Buraya Bakılacak
            }
            catch (Exception ex)
            {

                throw new Exception("Passengerlogin ID'yi getirirken datamapperda oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return 0;
        }

    }
}
