using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class LoginPassangerBussiness : IBussinessLayer<LoginPassenger, int>
    {
        LoginPassengerDataMapper _loginPassengerMapper = new LoginPassengerDataMapper();

        public List<LoginPassenger> GetAllBLL()
        {
            throw new NotImplementedException();
        }

        public LoginPassenger GetBLL(int key)
        {

            throw new NotImplementedException();
        }

        public bool SaveBLL(LoginPassenger item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBLL(LoginPassenger item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBLL(LoginPassenger item)
        {
            throw new NotImplementedException();
        }

        public int GetIdCorrectLoginBLL(LoginPassenger item)
        {
            return _loginPassengerMapper.GetIdCorrectLogin(item);
        }

    }
}
