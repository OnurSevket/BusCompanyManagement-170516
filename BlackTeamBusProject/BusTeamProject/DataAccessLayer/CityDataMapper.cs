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
  public  class CityDataMapper : IDataMapper<City, int>
    {
        SqlCommand _command;
        public CityDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public City Get(int key)
        {
            /*
            *create procedure sp_GetCityByID
              @id int
              as
              select ID,Name from City where ID=@id
             
            */
            _command.CommandText = "sp_GetCityByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);

            try
            {
                City city = null;
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        city = new City();
                        city.ID = (int)reader[0];
                        city.Name = reader[1].ToString();
                    }
                return city;

            }
            catch (Exception ex)
            {
                throw new Exception("İlleri getirken  bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }

        public List<City> GetAll()
        {
            /*
             create procedure sp_GetAllCity
               as
               select ID,Name from City

             */
            _command.CommandText = "sp_GetAllCity";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();

            try
            {
                List<City> cityList = new List<City>() ;
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        City city = new City();
                        city.ID = (int)reader[0];
                        city.Name = reader[1].ToString();

                        cityList.Add(city);
                    }
                return cityList;

            }
            catch (Exception ex)
            {
                throw new Exception("İlleri getirirken bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }

        public int Insert(City item)
        {
            /*
             *   create procedure sp_InsertCity
                    @name nvarchar(50)
                    as
                    begin
                        insert into City(Name)values(@name)
                    end
             */
            _command.CommandText = "sp_InsertCity";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
            int affectedRow = 0;
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRow = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("İl eklerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Update(City item)
        {
            /*
             *create procedure sp_UpdateCity
                @name nvarchar(50),
                @id int
                as
                begin
                   update City set Name=@name where ID=@id
                end

             */
            _command.CommandText = "sp_UpdateCity";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
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
                throw new Exception("İl güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Delete(City item)
        {
            /*
             *  create procedure sp_DeleteCity
                 @id int
                 as
                 begin
                 	delete from City where ID=@id
                 end
             */
            _command.CommandText = "sp_DeleteCity";
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
                throw new Exception("İl silerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }
    }
}
