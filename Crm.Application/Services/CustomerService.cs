using Crm.Application.Interfaces;
using Crm.Domain.Convertors;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Customer;
using Crm.Domain.ViewModel.Customer;
using Crm.Domain.ViewModel.DataTable;

namespace Crm.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<DtResult<CustomerViewModel>> GetData(DtParameters dtParameters)
    {
        var result = _customerRepository.GetData(dtParameters);
        return await result;
    }

    public void AddCustomer(AddCustomerViewModel model)
    {
        var customer = new Customer()
        {
            DateOfBirth = model.DateOfBirth.ToDateTime(),
            DateOfMarriageAnniversary = model.DateOfMarriageAnniversary?.ToDateTime(),
            DateOfBirthSpouse = model.DateOfBirthSpouse?.ToDateTime(),
            PhoneNumber = model.PhoneNumber,
            Address = model.Address,
            Description = model.Description,
            UserId = model.UserId,
            TownshipId = model.TownshipId,
            FullName = model.FullName,
            MaritalStatusId = model.MaritalStatusId,
            NationalCode = model.NationalCode,
            ProvinceId = model.ProvinceId,
        };
        AddCustomer(customer);
    }

    public void AddCustomer(Customer customer)
    {
        _customerRepository.AddCustomer(customer);
    }

    public void UpdateCustomer(EditCustomerViewModel model)
    {
        var customer = GetCustomerByCustomerIdCustomer(model.CustomerId);

        if (customer == null)
            return;

        customer.UserId = model.UserId;
        customer.ProvinceId = model.ProvinceId;
        customer.TownshipId = model.TownshipId;
        customer.MaritalStatusId = model.MaritalStatusId;
        customer.FullName = model.FullName;
        customer.NationalCode = model.NationalCode;
        customer.PhoneNumber = model.PhoneNumber;
        customer.Address = model.Address;
        customer.Description = model.Description;
        customer.DateOfBirth = model.DateOfBirth.ToDateTime();
        customer.DateOfMarriageAnniversary = model.DateOfMarriageAnniversary?.ToDateTime();
        customer.DateOfBirthSpouse = model.DateOfBirthSpouse?.ToDateTime();

        UpdateCustomer(customer);
    }

    public void UpdateCustomer(Customer customer)
    {
        customer.UpdateDate = DateTime.Now;
        _customerRepository.UpdateCustomer(customer);
    }

    public bool IsNationalCodeExist(int customerId, string nationalCode)
    {
        return _customerRepository.IsNationalCodeExist(customerId, nationalCode);
    }

    public bool IsPhoneNumberExist(int customerId, string phoneNumber)
    {
        return _customerRepository.IsPhoneNumberExist(customerId, phoneNumber);
    }

    public Customer? GetCustomerByCustomerIdCustomer(int customerId)
    {
        return _customerRepository.GetCustomerByCustomerIdCustomer(customerId);
    }

    public EditCustomerViewModel? GetCustomerViewModel(int customerId)
    {
        var customer = GetCustomerByCustomerIdCustomer(customerId);

        if (customer == null)
            return null;

        return new EditCustomerViewModel()
        {
            DateOfBirth = customer.DateOfBirth.ToShamsi(),
            DateOfBirthSpouse = customer.DateOfBirthSpouse?.ToShamsi(),
            DateOfMarriageAnniversary = customer.DateOfMarriageAnniversary?.ToShamsi(),
            Address = customer.Address,
            CustomerId = customer.CustomerId,
            PhoneNumber = customer.PhoneNumber,
            FullName = customer.FullName,
            NationalCode = customer.NationalCode,
            Description = customer.Description,
            MaritalStatusId = customer.MaritalStatusId,
            ProvinceId = customer.ProvinceId,
            TownshipId = customer.TownshipId,
            UserId = customer.UserId
        };

    }

    public void DeleteCustomer(int customerId, int userId)
    {
        var customer = GetCustomerByCustomerIdCustomer(customerId);

        if (customer == null)
            return;

        customer.DeleteDate=DateTime.Now;
        customer.UserId = userId;

        UpdateCustomer(customer);
    }
}