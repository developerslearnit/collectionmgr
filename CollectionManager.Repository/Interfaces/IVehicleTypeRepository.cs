using CollectionManager.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.Repository.Interfaces
{
    public interface IVehicleTypeRepository
    {
        IEnumerable<VehicleTypeModel> GetVehicles();

        bool saveVehicleType(VehicleTypeModel model);
    }
}
