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
    public class PassengerDataMapper:IDataMapper<Passenger,int>
    {
        SqlCommand _command;

        public PassengerDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public Passenger Get(int key)
        {
            /*             
                create proc sp_GetPassengerByID
                @id int
                as
                select ID,SocialNumber,FirstName,LastName,Gender,Telephone,Email from Passenger where ID=@id                      
             */
            _command.CommandText = "sp_GetPassengerByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);
            Passenger passenger = new Passenger();
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

                        passenger.ID = (int)reader[0];
                        passenger.SocialNumber = Convert.ToString(reader[1]);
                        passenger.FirstName = Convert.ToString(reader[2]);
                        passenger.LastName = Convert.ToString(reader[3]);
                        passenger.Gender = Convert.ToBoolean(reader[4]);
                        passenger.Telephone = Convert.ToString(reader[5]);
                        passenger.Email = (string)reader[6];

                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Passengerleri getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }


            


            return passenger;
        }

        public List<Passenger> GetAll()
        {
            /*             
                create proc sp_GetAllPassenger
                as
                select ID,SocialNumber,FirstName,LastName,Gender,Telephone,Email from Passenger                      
             */

            List<Passenger> passengerList = new List<Passenger>();
            _command.CommandText = "sp_GetAllPassenger";
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
                        Passenger passenger = new Passenger();
                        passenger.ID = (int)reader[0];
                        passenger.SocialNumber = Convert.ToString(reader[1]);
                        passenger.FirstName = Convert.ToString(reader[2]);
                        passenger.LastName = Convert.ToString(reader[3]);
                        passenger.Gender = Convert.ToBoolean(reader[4]);
                        passenger.Telephone = Convert.ToString(reader[5]);
                        passenger.Email = (string)reader[6]; ;

                        passengerList.Add(passenger);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Passenger listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return passengerList;
        }
        int lastIndex;
        public int Insert(Passenger item)
        {
            int affectedRows = 0;
            /*  
                create proc sp_InsertPassenger
                @socialNumber nvarchar(50),
                @firstName nvarchar(50),
                @lastName nvarchar(50),
                @gender bit,
                @telephone nvarchar(50),
                @email nvarchar(50)
                as
                begin
                Insert into Passenger(SocialNumber,FirstName,LastName,Gender,Telephone,Email) values(@socialNumber,@firstName,@lastName,@gender,@telephone,@email)
                SELECT SCOPE_IDENTITY()
                end    
                         
             */
            _command.CommandText = "sp_InsertPassenger";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@socialNumber", item.SocialNumber);
            _command.Parameters.AddWithValue("@firstName", item.FirstName);
            _command.Parameters.AddWithValue("@lastName", item.LastName);
            _command.Parameters.AddWithValue("@gender", item.Gender);
            _command.Parameters.AddWithValue("@telephone", item.Telephone);
            _command.Parameters.AddWithValue("@email", item.Email);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                
                Object lastIndexObje = _command.ExecuteScalar();
                lastIndex = int.Parse(lastIndexObje.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Passenger Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            /*
               create procedure sp_InsertLoginPassenger
               @ID int,
               @name nvarchar(50),
               @password nvarchar(50)
               as
               begin
                   insert into LoginPassenger(ID,Name,Password)values(@ID,@name,@password)
               end
                */
            _command.CommandText = "sp_InsertLoginPassenger";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@ID", lastIndex);
            _command.Parameters.AddWithValue("@name", item.Login.Name);
            _command.Parameters.AddWithValue("@password", item.Login.Password);
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();

                affectedRows = _command.ExecuteNonQuery();
                if (affectedRows > 0)
                { }
                else
                    throw new Exception("Login eklenmedi");
            }
            catch (Exception ex)
            {
                throw new Exception("Login: Login  eklerken hata oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }







            return affectedRows;
        }

        public int Update(Passenger item)
        {
            /*

                create proc sp_UpdatePassenger
                @id int,
                @socialNumber nvarchar(50),
                @firstName nvarchar(50),
                @lastName nvarchar(50),
                @gender bit,
                @telephone nvarchar(50),
                @email nvarchar(50)
                as
                begin
                Update Passenger set SocialNumber=@socialNumber,FirstName=@firstName,LastName=@lastName,Gender=@gender,Telephone=@telephone,Email=@email where ID=@id
                end

              */

            int affectedRows = 0;
            _command.CommandText = "sp_UpdatePassenger";
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@socialNumber", item.SocialNumber);
            _command.Parameters.AddWithValue("@firstName", item.FirstName);
            _command.Parameters.AddWithValue("@lastName", item.LastName);
            _command.Parameters.AddWithValue("@gender", item.Gender);
            _command.Parameters.AddWithValue("@telephone", item.Telephone);
            _command.Parameters.AddWithValue("@email", item.Email);
            _command.Parameters.AddWithValue("@id", item.ID);


            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Passenger Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Delete(Passenger item)
        {
            /*
                create proc sp_DeletePassenger
                @id int
                as
                begin
                Delete from Passenger where ID=@id
                end
            */


            int affectedRows = 0;

            _command.CommandText = "sp_DeletePassenger";
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
                throw new Exception("Passenger Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        
    }
}
