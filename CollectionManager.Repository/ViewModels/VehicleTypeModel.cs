using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.Repository.ViewModels
{
   public class VehicleTypeModel
    {
        public int vehicleId { get; set; }
        public string vehicleName { get; set; }
        public int createdBy { get; set; }
        public int lastUpdatedBy { get; set; }
    }
}
