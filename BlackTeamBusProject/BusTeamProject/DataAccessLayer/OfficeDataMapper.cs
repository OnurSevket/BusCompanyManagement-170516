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
    public class OfficeDataMapper : IDataMapper<Office, int>
    {
        SqlCommand _command;
        public OfficeDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }


        public Office Get(int key)
        {
            /*
            create procedure sp_GetOfficeByID
             @id int
             as
             select ID,OfficeName,DistinctID,IsCenterOffice from Office where ID=@id

             */
            _command.CommandText = "sp_GetOfficeByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);
            Office office = new Office();
            try
            {

                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        
                        office.ID = (int)reader[0];
                        office.OfficeName = reader[1].ToString();
                        office.DistictID = (int)reader[2];
                        office.IsCenterOffice = (bool)reader[3];
                    }


            }
            catch (Exception ex)
            {
                throw new Exception("Office getirilirken  bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            /*
                  
               begin try
               drop procedure sp_GetEmployeeInOfficeByID
               end try
               begin catch 
               end catch
               go
               create procedure sp_GetEmployeeInOfficeByID
                @officeID int
                as
                begin 
                    select OfficeID,EmployeeID from  BranchEmployee  where OfficeID=@officeID
                end
                go
                 */
            _command.CommandText = "sp_GetEmployeeInOfficeByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@officeID", key);

            try
            {

                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        EmployeeDataMapper employeeDataMapper = new EmployeeDataMapper();
                        int employeeID = (int)reader[1];
                        Employee employee = employeeDataMapper.Get(employeeID);
                        office.EmployeeList.Add(employee); ;
                    }
                }


            }
            catch (Exception ex)
            {

                throw new Exception("Bu Bus tipinine ait kayt bulunamadı !!" + ex.Message);
            }

            finally
            {
                _command.Connection.Close();
            }
            return office;
        }

        public List<Office> GetAll()
        {
            /*
                create procedure sp_GetAllOffice
                 as
                 select ID,OfficeName,DistinctID,IsCenterOffice from Office

             */
            _command.CommandText = "sp_GetAllOffice";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();

            try
            {
                List<Office> officeList = new List<Office>();
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        Office office = new Office();
                        office.ID = (int)reader[0];
                        office.OfficeName = reader[1].ToString();
                        office.DistictID = (int)reader[2];
                        office.IsCenterOffice = (bool)reader[3];
                        officeList.Add(office);
                    }
              
                return officeList;

            }
            catch (Exception ex)
            {
                throw new Exception("Officeleri getirirken bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }
        int lastIndex = 0;
        public int Insert(Office item)
        {
            /*
             	 create procedure sp_InsertOffice
                @officeName nvarchar(50),
                @districtId int,
	             @isCenterOffice bit
                as
                begin
                    insert into Office(OfficeName,DistinctID,IsCenterOffice) values(@officeName,@districtId,@isCenterOffice)
                    SELECT SCOPE_IDENTITY()
                end

             */
            int affectedRows = 0;
            _command.CommandText = "sp_InsertOffice";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@officeName", item.OfficeName);
            _command.Parameters.AddWithValue("@districtId", item.DistictID);
            _command.Parameters.AddWithValue("@isCenterOffice", item.IsCenterOffice);
            
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                Object lastIndexObje = _command.ExecuteScalar();
                lastIndex = int.Parse(lastIndexObje.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("Office eklerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            /// Ara tabloya insert işlemi yapılması için yapıldı 

            foreach (Employee _employee in item.EmployeeList)
            {
                _command.Parameters.Clear();

                /*
                   begin try
                   drop procedure sp_AddBranchEmployee
                   end try
                   begin catch 
                   end catch
                    go
                    create procedure sp_AddBranchEmployee
                     @officeID int,
                     @employeeID int
                     as
                     begin 
                       insert into BranchEmployee(OfficeID,EmployeeID) values (@officeID,@employeeID)
                     end
                 */
                _command.CommandText = "sp_AddBranchEmployee";
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@employeeID",_employee.ID );
                _command.Parameters.AddWithValue("@officeID", lastIndex);
                try
                {
                    if (_command.Connection.State == System.Data.ConnectionState.Closed)
                        _command.Connection.Open();

                    affectedRows = _command.ExecuteNonQuery();
                    if (affectedRows > 0)
                    { }
                    else
                        throw new Exception("BranchEmployee eklenmedi");
                }
                catch (Exception ex)
                {
                    throw new Exception("OfficeDataMapper:Branch Employee eklerken hata oluştu :" + ex.Message);
                }
                finally
                {
                    _command.Connection.Close();
                }
            }


            return lastIndex;
        }

        public int Update(Office item)
        {
            //Ara tablodaki kayıtları silme ve ekleme işlemleri yapıyor işlemi yapıyor
            _command.Parameters.Clear();
            /*
             create procedure sp_DeleteBranchEmployeeById
              @officeID int
              as
              begin
              	delete from BranchEmployee where OfficeID=@officeID 
              end
   
             */
            int affectedRows = 0;
            _command.CommandText = "sp_DeleteBranchEmployeeById";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add("@officeID", item.ID);
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Office Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            //Ara tabloya güncel değerler kaydediliyor
            foreach (Employee _employee in item.EmployeeList)
            {
                _command.Parameters.Clear();

                /*
                  
                 * 
                 create procedure sp_AddBranchEmployee
                   @officeID int,
                   @employeeID int
                   as
                   begin 
                     insert into BranchEmployee(OfficeID,EmployeeID) values (@officeID,@employeeID)
                   end
                 */
                _command.CommandText = "sp_AddBranchEmployee";
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@officeID", item.ID);
                _command.Parameters.AddWithValue("@employeeID", _employee.ID);
                try
                {
                    if (_command.Connection.State == System.Data.ConnectionState.Closed)
                        _command.Connection.Open();

                    affectedRows = _command.ExecuteNonQuery();
                    if (affectedRows > 0)
                    { }
                    else
                        throw new Exception("Branch Employee eklenmedi");
                }
                catch (Exception ex)
                {
                    throw new Exception("OfficeDataMapper: BranchEmployee eklerken hata oluştu :" + ex.Message);
                }
                finally
                {
                    _command.Connection.Close();
                }
            }


            /*
             create procedure sp_UpdateOffice
                 @officeName nvarchar(50),
                 @districtId int,
                 @isCenterOffice bit,
                 @id int
                  as
                  begin
                     update Office set OfficeName=@officeName,DistinctID=@districtId,IsCenterOffice=@isCenterOffice where ID=@id
                  end


             */
            _command.CommandText = "sp_UpdateOffice";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@officeName", item.OfficeName);
            _command.Parameters.AddWithValue("@districtId", item.DistictID);
            _command.Parameters.AddWithValue("@isCenterOffice", item.IsCenterOffice);
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
                throw new Exception("Office güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }

        public int Delete(Office item)
        {
            //Ara tablodaki kayıtların da silinmesi işleminin yapılması
            _command.Parameters.Clear();
            /*
             create procedure sp_DeleteBranchEmployeeById
               @officeID int
               as
               begin
               	delete from BranchEmployee where OfficeID=@officeID 
               end
		
             */
            int affectedRows = 0;
            _command.CommandText = "sp_DeleteBranchEmployeeById";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add("@officeID", item.ID);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Branch Employee update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }


            /*
              create procedure sp_DeleteOffice
              @id int
              as
              begin 
                delete from Office where ID=@id
              end
             */
            _command.CommandText = "sp_DeleteOffice";
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
                throw new Exception("Office silerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRow;
        }
    }
}
