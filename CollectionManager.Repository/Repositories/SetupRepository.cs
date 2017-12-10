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
    public class SetupRepository : Repository.BaseRepository<CollectionManagerEntities>,
        ISetupRepository
    {
        public IQueryable<BloodGroupViewModel> GetBloodGroups()
        {
            return DataContext.BloodGroups.Select(x => new BloodGroupViewModel
            {
                bloodGroupId = x.BloodGroupId,
                bloodGroupName = x.BloodGroupName
            });
        }

        public IQueryable<LGAViewModel> GetLGAs()
        {
            return DataContext.Lgas.Select(x => new LGAViewModel
            {
                lgaId = x.LgaId,
                lgaName =x.LgaName
            });
        }
    }
}
