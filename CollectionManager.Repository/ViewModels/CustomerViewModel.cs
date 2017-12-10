using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.Repository.ViewModels
{
    public class CustomerViewModel
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public int lgaId { get; set; }
        public string lgaName { get; set; }
        public int bloodGroupId { get; set; }
        public string bloodGroupName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int createdBy { get; set; }
    }
}
