using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public  class RoleBussiness : IBussinessLayer<Role, int>
    {
        RoleDataMapper _roleMapDataMapper = new RoleDataMapper();

        public List<Role> GetAllBLL()
        {
            List<Role> allRole = _roleMapDataMapper.GetAll();
            if (allRole.Count > -1)
            {
                return allRole;
            }
            else
            {
                throw new Exception("allRole listesi boş geliyor ");
            }
        }

        public Role GetBLL(int key)
        {
            if (key > 0)
            {
                Role role = _roleMapDataMapper.Get(key);
                return role;
            }
            else
            {
                throw new Exception("lütfen seçim yapınız");
            }
        }

        public bool SaveBLL(Role item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.RoleName) || item.RoleName == null)
                {
                    throw new Exception("Role RoleName Save yapılamadı + 002 ");
                }               
                affectedRows = _roleMapDataMapper.Insert(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Role veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            return result;
        }

        public bool UpdateBLL(Role item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.RoleName) || item.RoleName == null)
                {
                    throw new Exception("Role RoleName Save yapılamadı + 002 ");
                }
                affectedRows = _roleMapDataMapper.Update(item);

                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                }
                else
                    throw new Exception("Role veri tabanında Hiçbir kayıt etkilenmedi #Update");
            }
            return result;
        }

        public bool DeleteBLL(Role item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _roleMapDataMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else
            {
                throw new Exception("lütfen seçim yapınız |Role #Delete + 002");
            }
            return result;
        }


    }
}
