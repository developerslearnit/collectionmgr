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
    public class CustomerRepository : Repository.BaseRepository<CollectionManagerEntities>,
        ICustomerRepository
    {
        public bool AddCustomer(CustomerViewModel customer)
        {
            var newCustomer = new Customer()
            {
                BloodGroupId = customer.bloodGroupId,
                CreatedBy = customer.createdBy,
                DateTimeCreated =DateTime.Now,
                Email =customer.email,
                FirstName =customer.firstName,
                MiddleName =customer.middleName,
                LastName =customer.lastName,
                Phone = customer.phone,
                LgaId =customer.lgaId
            };

            DataContext.Customers.Add(newCustomer);
            return DataContext.SaveChanges() > 0;
        }

        public IQueryable<CustomerViewModel> GetCustomers()
        {
            return from cust in DataContext.Customers join lg in DataContext.Lgas
                        on cust.LgaId equals lg.LgaId join bg in DataContext.BloodGroups
                        on cust.BloodGroupId equals bg.BloodGroupId
                       select new CustomerViewModel
                       {
                           bloodGroupId = bg.BloodGroupId,
                           bloodGroupName =bg.BloodGroupName,
                           customerId =cust.CustomerId,
                           createdBy =cust.CreatedBy,
                           email =cust.Email,
                           firstName =cust.FirstName,
                           lastName =cust.LastName,
                           lgaId =lg.LgaId,
                           lgaName =lg.LgaName,
                           middleName =cust.MiddleName,
                           phone =cust.Phone
                       };
        }
    }
}
