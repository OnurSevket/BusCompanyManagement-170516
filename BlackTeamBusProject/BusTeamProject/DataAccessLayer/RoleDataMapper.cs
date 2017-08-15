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
    public class RoleDataMapper : IDataMapper<Role, int>
    {
        SqlCommand _command;

        public RoleDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public Role Get(int key)
        {
            /*             
                create proc sp_GetRole
                 @Id int
                 as
                 begin
                 select ID, RoleName from Role where ID = @Id                       
             */
            _command.CommandText = "sp_GetRole";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@Id", key);
            Role role = new Role() ;
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
                        role = new Role();
                        role.ID = (int)reader["ID"];
                        role.RoleName = reader["RoleName"].ToString();
                        
                    }
                }

                

                

            }
            catch (Exception ex)
            {

                throw new Exception("Role getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            /*
                   begin try
                    drop procedure sp_GetRoleAuthoryByID
                    end try
                    begin catch 
                    end catch
                    go
                    create procedure sp_GetRoleAuthoryByID
                     @roleID int
                     as
                     begin 
                         select RoleID,AuthorID from  RoleAuthory  where RoleID=@roleID
                     end
                     go
                 */
            _command.CommandText = "sp_GetRoleAuthoryByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@roleID", key);

            try
            {

                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        AuthoryDataMapper authoryDataMapper = new AuthoryDataMapper();
                        int authoryID = (int)reader[1];
                        Authory authory = authoryDataMapper.Get(authoryID);
                        role.AuthoryList.Add(authory); ;
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
            return role;
        }

        public List<Role> GetAll()
        {
            /*             
               alter proc sp_GetRoleList
              
                as
                begin
                select ID,AuthorityID, RoleName from Role 
                end                        
             */
            List<Role> roleList = new List<Role>();

            _command.CommandText = "sp_GetRoleList";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            try
            {
                roleList = new List<Role>();
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role useRole = new Role();
                        useRole.ID = Convert.ToInt32(reader["ID"]);
                        useRole.RoleName = reader["RoleName"].ToString();

                        roleList.Add(useRole);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Rol listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return roleList ;   //todo:
        }
        int lastIndex;
        public int Insert(Role item)
        {
            int affectedRows = 0;
            /*  
                 alter proc sp_AddRoleInsert    --Insert Bus
		          @roleName nvarchar(50) 
                as 
                begin
                Insert Role(RoleName) values (@roleName) 
                SELECT SCOPE_IDENTITY()
                end           
             */
            _command.CommandText = "sp_AddRoleInsert";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@roleName",item.RoleName);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                Object lastIndexObje = _command.ExecuteScalar();
                lastIndex = int.Parse(lastIndexObje.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Role Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            /// Ara tabloya insert işlemi yapılması için yapıldı 

            foreach (Authory _authory in item.AuthoryList)
            {
                _command.Parameters.Clear();

                /*
                  create procedure sp_AddRoleAuthory
                    @roleId int,
                    @authoryId int
                    as
                    begin 
                      insert into RoleAuthory(RoleID,AuthorID) values (@roleId,@authoryId)
                    end
                 */
                _command.CommandText = "sp_AddRoleAuthory";
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@roleID",lastIndex);
                _command.Parameters.AddWithValue("@authoryId",_authory.ID);
                try
                {
                    if (_command.Connection.State == System.Data.ConnectionState.Closed)
                        _command.Connection.Open();

                    affectedRows = _command.ExecuteNonQuery();
                    if (affectedRows > 0)
                    { }
                    else
                        throw new Exception("Role Authory eklenmedi");
                }
                catch (Exception ex)
                {
                    throw new Exception("RoleDataMapper: Role Authory eklerken hata oluştu :" + ex.Message);
                }
                finally
                {
                    _command.Connection.Close();
                }
            }


            return affectedRows;
        }

        public int Update(Role item)
        {
            //Ara tablodaki kayıtları silme ve ekleme işlemleri yapıyor işlemi yapıyor
            _command.Parameters.Clear();
            /*create procedure sp_DeleteRoleAuthoryById
               @roleID int
               as
               begin
               	delete from RoleAuthory where RoleId=@roleID 
               end
             */
            int affectedRows = 0;
            _command.CommandText = "sp_DeleteRoleAuthoryById";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add("@roleID", item.ID);
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Role Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            //Ara tabloya güncel değerler kaydediliyor
            foreach (Authory _authory in item.AuthoryList)
            {
                _command.Parameters.Clear();

                /*
                  create procedure sp_AddRoleAuthory
                    @roleId int,
                    @authoryId int
                    as
                    begin 
                      insert into RoleAuthory(RoleID,AuthorID) values (@roleId,@authoryId)
                    end
                 */
                _command.CommandText = "sp_AddRoleAuthory";
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@roleID", item.ID);
                _command.Parameters.AddWithValue("@authoryId", _authory.ID);
                try
                {
                    if (_command.Connection.State == System.Data.ConnectionState.Closed)
                        _command.Connection.Open();

                    affectedRows = _command.ExecuteNonQuery();
                    if (affectedRows > 0)
                    { }
                    else
                        throw new Exception("Role Authory eklenmedi");
                }
                catch (Exception ex)
                {
                    throw new Exception("RoleDataMapper: Role Authory eklerken hata oluştu :" + ex.Message);
                }
                finally
                {
                    _command.Connection.Close();
                }
            }

            /*
                 alter proc sp_UpdateRole
	            @roleName nvarchar(50),
	            @Id int
		            as 
		            begin
		            update Role set RoleName = @roleName where Role.ID = @Id 
		            end
             */

            
            _command.Parameters.Clear();
            _command.CommandText = "sp_UpdateRole";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@roleName", item.RoleName);
            _command.Parameters.AddWithValue("@Id",item.ID);


            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Role Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            


            return affectedRows;
        }

        public int Delete(Role item)
        {
            //Ara tablodaki kayıtların da silinmesi işleminin yapılması
            _command.Parameters.Clear();
            /*create procedure sp_DeleteRoleAuthoryById
               @roleID int
               as
               begin
               	delete from RoleAuthory where RoleId=@roleID 
               end
             */
            int affectedRows = 0;
            _command.CommandText = "sp_DeleteRoleAuthoryById";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add("@roleID", item.ID);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Role Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }


            /*
               alter proc sp_DeleteRole
	            @Id int
	            as
	            begin
	            delete from Role where Role.ID = @Id
	            end
	            go
           */


            

            _command.CommandText = "sp_DeleteRole";
            _command.CommandType = CommandType.StoredProcedure;


            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@Id", item.ID);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Role Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            
            return affectedRows;
        }

    }
}
