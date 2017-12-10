using CollectionManager.Data;
using CollectionManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionManager.Repository.ViewModels;

namespace CollectionManager.Repository.Repositories
{
    public class UserRepository : Repository.BaseRepository<CollectionManagerEntities>,
        IUserRepository
    {
        public bool AddUser(UserVModel model)
        {
            var newUser = new User()
            {
                Username = model.username,
                IsLocked = false,
                IsActive =true,
                Password = model.password,
                SecurityAnswer =model.securityQuestion,
                SecurityQuestion =model.securityAnswer,
                DateTimeCreated = DateTime.Now,
                FailedLogonAttempt = 0,
                IsFirstLoginAttempt = false,
                LastLoginDate = DateTime.Now
            };
            DataContext.Users.Add(newUser);

            return DataContext.SaveChanges() > 0;

        }

        public IQueryable<UsersViewModel> GetAllUsers()
        {
            return DataContext.Users.Select(x => new UsersViewModel
            {
                UserId =x.UserId,
                Username = x.Username,
                FailedLogonAttempt =x.FailedLogonAttempt.Value,
                IsActive =x.IsActive,
                IsLocked =x.IsLocked,
                LastLoginDate =x.LastLoginDate
            });
        }
    }
}
