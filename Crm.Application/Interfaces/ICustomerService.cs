using Crm.Domain.Models.Customer;
using Crm.Domain.ViewModel.Customer;
using Crm.Domain.ViewModel.DataTable;

namespace Crm.Application.Interfaces;

public interface ICustomerService
{
    Task<DtResult<CustomerViewModel>> GetData(DtParameters dtParameters);
    void AddCustomer(AddCustomerViewModel model);
    void AddCustomer(Customer customer);
    
    void UpdateCustomer(EditCustomerViewModel model);
    void UpdateCustomer(Customer customer);
    
    bool IsNationalCodeExist(int customerId,string nationalCode);
    bool IsPhoneNumberExist(int customerId, string phoneNumber);

    Customer? GetCustomerByCustomerIdCustomer(int customerId);
    EditCustomerViewModel? GetCustomerViewModel(int customerId);
    void DeleteCustomer(int customerId, int userId);
}