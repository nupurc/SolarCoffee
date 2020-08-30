using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Customer
{
   public interface ICustomerService
    {
        List<Data.Model.Customer> GetAllCustomers();
        ServiceResponse<Data.Model.Customer> CreateCustomer(Data.Model.Customer customer);
        ServiceResponse<bool> DeleteCustomer(int id);
        Data.Model.Customer GetById(int id);
    }
}
