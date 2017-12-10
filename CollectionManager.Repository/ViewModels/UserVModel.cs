using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.Repository.ViewModels
{
    public class UserVModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string securityQuestion { get; set; }
        public string securityAnswer { get; set; }
    }
}
