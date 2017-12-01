using CollectionManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CollectionManager.Repository.ViewModels;
using CollectionManager.Data;

namespace CollectionManager.Repository.Repositories
{
    public class VehicleTypeRepository : Repository.BaseRepository<CollectionManagerEntities>,
        IVehicleTypeRepository
    {
        public IEnumerable<VehicleTypeModel> GetVehicles()
        {
            return DataContext.VehicleTypes.Select(x => new VehicleTypeModel {
                createdBy = x.CreatedBy,
                vehicleId =x.VehicleId,
                vehicleName =x.VehicleName,
                lastUpdatedBy =x.LastUpdatedBy.Value,
            });
        }

        public bool saveVehicleType(VehicleTypeModel model)
        {
            var newVehicleType = new VehicleType()
            {
                VehicleName = model.vehicleName,
                CreatedBy = model.createdBy,
                LastUpdatedBy =model.lastUpdatedBy,
                DateTimeCreated =DateTime.Now               
            };

            DataContext.VehicleTypes.Add(newVehicleType);

            return DataContext.SaveChanges() > 0;
        }
    }
}
