using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSharing.BLL.BLLEtities;
using PhotoSharing.BLL.Interfaces;
using PhotoSharing.DAL.Interfaces;
using PhotoSharing.DAL.Entities;
using AutoMapper;
using PhotoSharing.BLL.Infrastructure;

namespace PhotoSharing.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        AutoMapperCollection mapperCollection;
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
            mapperCollection = new AutoMapperCollection();
        }
        public void EditUserInfo(UserBLL user)
        {
            User userToEdit = Mapper.Map<UserBLL, User>(user);
            Database.Users.Update(userToEdit);
            Database.Save();
        }

        public UserBLL FindUserByEmail(string email)
        {
            
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserBLL>>(Database.Users.GetAll()).FirstOrDefault(x => x.Email == email);
        }

        public void UserRegister(UserBLL user)
        {
            Database.Users.Create(Mapper.Map<UserBLL,User>(user));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
