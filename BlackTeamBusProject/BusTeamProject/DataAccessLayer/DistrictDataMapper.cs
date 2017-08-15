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
    public class DistrictDataMapper : IDataMapper<District,int>
    {
        SqlCommand _command;
        public DistrictDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public District Get(int key)
        {
            /*
              create procedure sp_GetDistrictByID
                @id int
                as
                select ID,Name,CityID from District where ID=@id

             */
            _command.CommandText = "sp_GetDistrictByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear(); 
            _command.Parameters.AddWithValue("@id",key);

            try
            {
                District district = null;
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        district = new District();
                        district.ID = (int)reader[0];
                        district.Name = reader[1].ToString();
                        district.CityID = (int)reader[2];
                    }
                return district;
            }
            catch (Exception ex)
            {
                throw new Exception("İlçeyi getirken  bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }

        public List<District> GetAll()
        {
            /*
             create procedure sp_GetAllDistrict
              as
              select ID,Name,CityID from District

             */
            _command.CommandText = "sp_GetAllDistrict";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();

            try
            {
                List<District> districtList = new List<District>();
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        District district = new District();
                        district.ID = (int)reader[0];
                        district.Name = reader[1].ToString();
                        district.CityID = (int)reader[2];

                        districtList.Add(district);
                    }
                return districtList;

            }
            catch (Exception ex)
            {
                throw new Exception("İlçeleri getirirken bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }

        public int Insert(District item)
        {
            /*
             * 
               create procedure sp_InsertDistrict
                 @name nvarchar(50),
                 @cityId int 
                 as
                 begin
                     insert into District(Name,CityID)values(@name,@cityId)
                 end
             */
            _command.CommandText = "sp_InsertDistrict";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@cityId", item.CityID);
            int affectedRow = 0;
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRow = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("İlçe eklerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Update(District item)
        {
            /*
             * create procedure sp_UpdateDistrict
                 @name nvarchar(50),
                 @cityID int ,
                 @id int
                 as
                 begin
                    update District set Name=@name,CityID=@cityID where ID=@id
                 end

             */
            _command.CommandText = "sp_UpdateDistrict";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@name", item.Name);
            _command.Parameters.AddWithValue("@cityID", item.CityID);
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
                throw new Exception("İlce güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Delete(District item)
        {
            /*
            * create procedure sp_DeleteDistrict
               @id int
               as
               begin
                delete from District where ID=@id
               end
            */
            _command.CommandText = "sp_DeleteDistrict";
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
                throw new Exception("ilçe silerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }
    }
}
