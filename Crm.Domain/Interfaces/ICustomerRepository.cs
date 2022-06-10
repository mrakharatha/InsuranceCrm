using Crm.Domain.Models.Customer;
using Crm.Domain.ViewModel.Customer;
using Crm.Domain.ViewModel.DataTable;

namespace Crm.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<DtResult<CustomerViewModel>> GetData(DtParameters dtParameters);
    bool IsNationalCodeExist( int customerId, string nationalCode);
    bool IsPhoneNumberExist(int customerId, string phoneNumber);
    void AddCustomer(Customer customer);
   void UpdateCustomer(Customer customer);
    Customer? GetCustomerByCustomerIdCustomer(int customerId);
}