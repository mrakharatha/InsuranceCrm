using System.Linq;
using Crm.Domain.Convertors;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Customer;
using Crm.Domain.ViewModel.Customer;
using Crm.Domain.ViewModel.DataTable;
using Crm.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infra.Data.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationContext _context;

    public CustomerRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<DtResult<CustomerViewModel>> GetData(DtParameters dtParameters)
    {
        var searchBy = dtParameters.Search?.Value;

        var result = _context.Customers.AsQueryable();

        if (!string.IsNullOrEmpty(searchBy))
        {
            result = result.Where(x =>
                    x.PhoneNumber.Contains(searchBy) ||
                    x.FullName.Contains(searchBy) ||
                    x.NationalCode.Contains(searchBy)
                    );
        }

        var filteredResultsCount = await result.CountAsync();
        var totalResultsCount = await _context.Customers.CountAsync();

        return new DtResult<CustomerViewModel>
        {
            Draw = dtParameters.Draw,
            RecordsTotal = totalResultsCount,
            RecordsFiltered = filteredResultsCount,
            Data = await result
                .OrderByDescending(r => r.CustomerId)
                .Skip(dtParameters.Start)
                .Take(dtParameters.Length)
                .Select(x => new CustomerViewModel()
                {
                    CreateDate = x.CreateDate.ToShamsi(),
                    CustomerId = x.CustomerId,
                    FullName = x.FullName,
                    NationalCode = x.NationalCode,
                    PhoneNumber = x.PhoneNumber,
                    DateOfBirth = x.DateOfBirth.ToShamsi()
                })

                .ToListAsync()
        };
    }

    public bool IsNationalCodeExist(int customerId, string nationalCode)
    {
        if (customerId == 0)
            return _context.Customers.Any(x => x.NationalCode.Equals(nationalCode));

        return _context.Customers.Any(x => x.NationalCode.Equals(nationalCode)  && x.CustomerId != customerId);
    }

    public bool IsPhoneNumberExist( int customerId, string phoneNumber)
    {
        if (customerId == 0)
            return _context.Customers.Any(x => x.PhoneNumber.Equals(phoneNumber));

        return _context.Customers.Any(x => x.PhoneNumber.Equals(phoneNumber)  && x.CustomerId != customerId);
    }

    public void AddCustomer(Customer customer)
    {
        _context.Add(customer);
        _context.SaveChanges();
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Update(customer);
        _context.SaveChanges();
    }

    public Customer? GetCustomerByCustomerIdCustomer(int customerId)
    {
        return _context.Customers.Find(customerId);
    }

    public List<SelectListItem> GetCustomer()
    {
        return _context.Customers
            .OrderByDescending(x => x.CustomerId)
            .Select(x => new SelectListItem()
            {
                Text = x.FullName+" - "+x.NationalCode,
                Value = x.CustomerId.ToString()
            })
            .ToList();
    }
}