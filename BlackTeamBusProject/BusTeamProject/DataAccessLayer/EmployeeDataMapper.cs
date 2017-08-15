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
  public  class EmployeeDataMapper :IDataMapper<Employee,int>
    {
        SqlCommand _command;

        public EmployeeDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }


        public Employee Get(int key)
        {
            /*
             create procedure sp_GetEmployeeByID
         @id int
         as
         select ID,SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email
          from Employee where ID=@id

             */
            _command.CommandText = "sp_GetEmployeeByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear(); 
            _command.Parameters.AddWithValue("@id",key);
            
            try
            {
                Employee employee = null;
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    { 
                        employee = new Employee();
                        employee.ID = (int)reader[0];
                        employee.SocialNumber = reader[1].ToString();
                        employee.FirstName = reader[2].ToString();
                        employee.LastName= reader[3].ToString();
                        employee.Gender=(bool)reader[4];
                        employee.DateOfBirth= ((DateTime)reader[5]).Date;
                        employee.StartWorkDate=(DateTime) reader[6];
                        employee.FinishWorkDate=(DateTime) reader[7];
                        employee.CreatedEmployeeID=reader[8]== DBNull.Value ? 0: (int)reader[8];
                        employee.RoleID=(int)reader[9];
                        employee.Telephone=reader[10].ToString();
                        employee.Email=reader[11].ToString();
                    }
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("Employee getirken  bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }

        public List<Employee> GetAll()
        {
            /*
             create procedure sp_GetAllEmployee
               as
               select ID,SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email
                from Employee

            */
            _command.CommandText = "sp_GetAllEmployee";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();

            try
            {
                List<Employee> employeList = new List<Employee>();
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = (int)reader[0];
                        employee.SocialNumber = reader[1].ToString();
                        employee.FirstName = reader[2].ToString();
                        employee.LastName = reader[3].ToString();
                        employee.Gender = (bool)reader[4];
                        employee.DateOfBirth = ((DateTime)reader[5]).Date;
                        employee.StartWorkDate = ((DateTime)reader[6]).Date;
                        employee.FinishWorkDate = ((DateTime)reader[7]).Date;
                        employee.CreatedEmployeeID = reader[8]==DBNull.Value ? 0 : (int)reader[8];
                        employee.RoleID = (int)reader[9];
                        employee.Telephone = reader[10].ToString();
                        employee.Email = reader[11].ToString();
                        employeList.Add(employee);
                    }
               
                return employeList;

            }
            catch (Exception ex)
            {
                throw new Exception("Çalışanları getirirken bir sorun oluştu :" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
        }
        int lastIndex;
        public int Insert(Employee item)
        {
            /*
            
           create procedure sp_InsertEmployee
            @socialNumber nchar(11),
            @firstName nvarchar(50),
            @lastName nvarchar(50),
            @gender bit,
            @dateofbirth date,
            @startWorkDate datetime ,
            @finishWorkDate datetime,
            @createdEmployeeID int,
            @roleID int,
            @telephone nvarchar(20),
            @email nvarchar(50)
            as
            begin
                insert into Employee
              (SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email)
              values
              (@socialNumber,@firstName,@lastName,@gender,@dateofbirth,@startWorkDate,@finishWorkDate,@createdEmployeeID,@roleID,@telephone,@email)
             SELECT SCOPE_IDENTITY()
             end
            */
            _command.CommandText = "sp_InsertEmployee";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@socialNumber", item.SocialNumber);
            _command.Parameters.AddWithValue("@firstName", item.FirstName);
            _command.Parameters.AddWithValue("@lastName", item.LastName);
            _command.Parameters.AddWithValue("@gender", item.Gender);
            _command.Parameters.AddWithValue("@dateofbirth", item.DateOfBirth);
            _command.Parameters.AddWithValue("@startWorkDate", item.StartWorkDate);
            _command.Parameters.AddWithValue("@finishWorkDate", item.FinishWorkDate);
            _command.Parameters.AddWithValue("@createdEmployeeID", item.CreatedEmployeeID);
            _command.Parameters.AddWithValue("@roleID", item.RoleID);
            _command.Parameters.AddWithValue("@telephone", item.Telephone);
            _command.Parameters.AddWithValue("@email", item.Email);

            int affectedRow = 0;
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                Object lastIndexObje = _command.ExecuteScalar();
                lastIndex = int.Parse(lastIndexObje.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("Çalışan eklerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            /// Ara tabloya insert işlemi yapılması için yapıldı 

            foreach (Office _office in item.OfficeList)
            {
                _command.Parameters.Clear();

                /*
                 create procedure sp_AddBranchEmployee
                   @officeID int,
                   @employeeID int
                   as
                   begin
                      insert into BranchEmployee(EmployeeID,OfficeID)values(@employeeID,@officeID)
                   end
                 */
                _command.CommandText = "sp_AddBranchEmployee";
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@employeeID", lastIndex);
                _command.Parameters.AddWithValue("@officeID", _office.ID);
                try
                {
                    if (_command.Connection.State == System.Data.ConnectionState.Closed)
                        _command.Connection.Open();

                    affectedRow = _command.ExecuteNonQuery();
                    if (affectedRow > 0)
                    { }
                    else
                        throw new Exception("EmployeeOffice eklenmedi");
                }
                catch (Exception ex)
                {
                    throw new Exception("EmployeeDataMapper: Employee office eklerken hata oluştu :" + ex.Message);
                }
                finally
                {
                    _command.Connection.Close();
                }
            }

            /*
               create procedure sp_InsertLogin
                  @ID int,
                   @name nvarchar(50),
                   @password nvarchar(50)
                   as
                   begin
                       insert into Login(ID,Name,Password)values(@ID,@name,@password)
                   end
                */
            _command.CommandText = "sp_InsertLogin";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@ID", lastIndex);
            _command.Parameters.AddWithValue("@name",item.Login.Name);
            _command.Parameters.AddWithValue("@password",item.Login.Password);
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();

                affectedRow = _command.ExecuteNonQuery();
                if (affectedRow > 0)
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


            return affectedRow;
        }

        public int Update(Employee item)
        {
            /*
            create procedure sp_UpdateEmployee
              @socialNumber nchar(11),
              @firstName nvarchar(50),
              @lastName nvarchar(50),
              @gender bit,
              @dateofbirth date,
              @startWorkDate datetime ,
              @finishWorkDate datetime,
              @createdEmployeeID int,
              @roleID int,
              @telephone nvarchar(20),
              @email nvarchar(50),
              @id int
              as
              begin
                  Update Employee
                 set SocialNumber=@socialNumber,FirstName=@firstName,LastName=@lastName,Gender=@gender,
                 DateOfBirth=@dateofbirth,StartWorkDate=@startWorkDate,FinishWorkDate=@finishWorkDate,
                 CreatedEmployeeID=@createdEmployeeID,RoleID=@roleID,Telephone=@telephone,Email=@email
                 where ID=@id
              end
             */
            _command.CommandText = "sp_UpdateEmployee";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@socialNumber", item.SocialNumber);
            _command.Parameters.AddWithValue("@firstName", item.FirstName);
            _command.Parameters.AddWithValue("@lastName", item.LastName);
            _command.Parameters.AddWithValue("@gender", item.Gender);
            _command.Parameters.AddWithValue("@dateofbirth", item.DateOfBirth);
            _command.Parameters.AddWithValue("@startWorkDate", item.StartWorkDate);
            _command.Parameters.AddWithValue("@finishWorkDate", item.FinishWorkDate);
            _command.Parameters.AddWithValue("@createdEmployeeID", item.CreatedEmployeeID);
            _command.Parameters.AddWithValue("@roleID", item.RoleID);
            _command.Parameters.AddWithValue("@telephone", item.Telephone);
            _command.Parameters.AddWithValue("@email", item.Email);
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
                throw new Exception("Çalışan  güncellenirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            //Ara tablodaki kayıtları silme ve ekleme işlemleri yapıyor işlemi yapıyor
            _command.Parameters.Clear();
            /*
             create procedure sp_DeleteBranchEmployeeByID
                   @employeeID int
                   as
                   begin
                      delete from BranchEmployee where EmployeeID=@employeeID
                   end
             */
            _command.CommandText = "sp_DeleteBranchEmployeeByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add("@employeeID", item.ID);
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRow = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("EmployeeOffice delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            /// Ara tabloya insert işlemi yapılması için yapıldı 

            foreach (Office _office in item.OfficeList)
            {
                _command.Parameters.Clear();

                /*
                 create procedure sp_AddBranchEmployee
                   @officeID int,
                   @employeeID int
                   as
                   begin
                      insert into BranchEmployee(EmployeeID,OfficeID)values(@employeeID,@officeID)
                   end
                 */
                _command.CommandText = "sp_AddBranchEmployee";
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@employeeID", lastIndex);
                _command.Parameters.AddWithValue("@officeID", _office.ID);
                try
                {
                    if (_command.Connection.State == System.Data.ConnectionState.Closed)
                        _command.Connection.Open();

                    affectedRow = _command.ExecuteNonQuery();
                    if (affectedRow > 0)
                    { }
                    else
                        throw new Exception("EmployeeOffice eklenmedi");
                }
                catch (Exception ex)
                {
                    throw new Exception("EmployeeDataMapper: Employee office eklerken hata oluştu :" + ex.Message);
                }
                finally
                {
                    _command.Connection.Close();
                }
            }

            return affectedRow;
        }

        public int Delete(Employee item)
        {///TODO Çalışan silinmemesi gerekiyor pasife çekme yapılabilir 
            /*
                create procedure sp_DeleteEmployee
               @id int
               as
               begin
                  delete from Employee where ID=@id
               end
             */
            _command.CommandText = "sp_DeleteEmployee";
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
                throw new Exception("Çalışan silerken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            //Ara tablodaki kayıtları silme ve ekleme işlemleri yapıyor işlemi yapıyor
            _command.Parameters.Clear();
            /*
             create procedure sp_DeleteBranchEmployeeByID
                   @employeeID int
                   as
                   begin
                      delete from BranchEmployee where EmployeeID=@employeeID
                   end
             */
            _command.CommandText = "sp_DeleteBranchEmployeeByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add("@employeeID", item.ID);
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRow = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("EmployeeOffice delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRow;
        }
    }
}
