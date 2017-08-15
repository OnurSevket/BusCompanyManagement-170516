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
   public class AddressDataMapper :IDataMapper<Address,int>
    {
        SqlCommand _command;

        public AddressDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
            

        }

        public Address Get(int key)
        {
            /*
             * create procedure sp_GetAddressByID
                @id int
                as
                select ID,Name,City,District from Address where ID=@id

             */
            _command.CommandText = "sp_GetAddressByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear(); 
            _command.Parameters.AddWithValue("@id",key);
            
            try
            {
                Address address = null;
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    { 
                        address = new Address();
                        address.ID = (int)reader[0];
                        address.Name = reader[1].ToString();
                        address.City = (int)reader[2];
                        address.District = (int)reader[3];
                        address.EmployeeID = (int)reader[4];
                    }

                return address;

            }
            catch (Exception ex)
            {
                throw new Exception("Adressi getirken  bir sorun oluştu :"+ex.Message );
            }
            finally
            {
                _command.Connection.Close();
            }

        }

        public List<Address> GetAll()
        {
            /*
             * create procedure sp_GetAllAdress
                 as
                 select ID,Name,City,District,EmployeeId from Address

             */
            _command.CommandText = "sp_GetAllAdress";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();

            try
            {
                List<Address> addresList = new List<Address>();
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        Address address = new Address();
                        address.ID = (int)reader[0];
                        address.Name = reader[1].ToString();
                        address.City = (int)reader[2];
                        address.District = (int)reader[3];
                        address.EmployeeID = (int)reader[4];
                        addresList.Add(address);
                    }
                
                return addresList;

            }
            catch (Exception ex)
            {
                throw new Exception("Adresleri getirirken bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }

        public int Insert(Address item)
        {
            /*
             * create procedure sp_InsertAddress
                @name nvarchar(50),
                @city int ,
                @district int,
                @employeeId int
                as
                begin
                    insert into Address(Name,City,District,EmployeeID)values(@name,@city,@district,@employeeId)
                end
             */
            _command.CommandText = "sp_InsertAddress";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear(); 
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@city", item.City);
            _command.Parameters.AddWithValue("@district", item.District);
            _command.Parameters.AddWithValue("@employeeId",item.EmployeeID);
            int affectedRow = 0;
            try
            {
                 if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                 affectedRow = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Adres eklerken bir sorun oluştu"+ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Update(Address item)
        {
            /*
             *create procedure sp_UpdateAddress
                @name nvarchar(50),
                @city int ,
                @district int,
                @employeeId int,
                @id int
                as
                begin
                   update Address set Name=@name,City=@city,District=@district,EmployeeID=@employeeId where ID=@id
                end

             */
            _command.CommandText = "sp_UpdateAddress";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear(); 
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@city", item.City);
            _command.Parameters.AddWithValue("@district", item.District);
            _command.Parameters.AddWithValue("@employeeId", item.EmployeeID);
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
                throw new Exception("Adres güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Delete(Address item)
        {
            /*
             * create procedure sp_DeleteAddress
                   @id int
                   as
                   begin
                   	delete from Address where ID=@id
                   end
             */
            _command.CommandText = "sp_DeleteAddress";
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
                throw new Exception("Adres silerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }
    }
}
