using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.Repository.ViewModels
{
    public class BloodGroupViewModel
    {
        public int bloodGroupId { get; set; }
        public string bloodGroupName { get; set; }
        public int createdBy { get; set; }
    }
}
