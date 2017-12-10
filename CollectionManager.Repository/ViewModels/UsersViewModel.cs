using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.Repository.ViewModels
{
    public class UsersViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public int FailedLogonAttempt { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public System.DateTime NextPasswordChangeDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> DeactivatedDate { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        
    }
}
