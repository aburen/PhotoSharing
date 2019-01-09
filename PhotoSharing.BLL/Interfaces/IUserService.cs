using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSharing.BLL.BLLEtities;

namespace PhotoSharing.BLL.Interfaces
{
    public interface IUserService
    {
        void UserRegister(UserBLL user);
        void EditUserInfo(UserBLL user);
        UserBLL FindUserByEmail(string email);
        void Dispose();
        
    }
}
