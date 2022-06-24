using Crm.Domain.Convertors;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Crm.Domain.ViewModel.Customer;
using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;
using Crm.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infra.Data.Repository;

public class InsuredRepository: IInsuredRepository
{
    private readonly ApplicationContext _context;

    public InsuredRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<DtResult<InsuredViewModel>> GetData(DtParameters dtParameters)
    {
        var searchBy = dtParameters.Search?.Value;

        var result = _context.Insureds.AsQueryable();

        if (!string.IsNullOrEmpty(searchBy))
        {
            result = result.Where(x =>
                x.Customer.FullName.Contains(searchBy) ||
                x.Insurance.Title.Contains(searchBy) ||
                x.PaymentMethod.Title.Contains(searchBy)
            );
        }

        var filteredResultsCount = await result.CountAsync();
        var totalResultsCount = await _context.Insureds.CountAsync();

        return new DtResult<InsuredViewModel>
        {
            Draw = dtParameters.Draw,
            RecordsTotal = totalResultsCount,
            RecordsFiltered = filteredResultsCount,
            Data = await result
                .OrderByDescending(r => r.InsuredId)
                .Skip(dtParameters.Start)
                .Take(dtParameters.Length)
                .Include(x=> x.Customer)
                .Include(x=> x.Insurance)
                .Include(x=> x.PaymentMethod)
                .Select(x => new InsuredViewModel()
                {
                    CreateDate = x.CreateDate.ToShamsi(),
                    Insurance = x.Insurance.Title,
                    PaymentMethod = x.PaymentMethod.Title,
                    InsuredId = x.InsuredId,
                    FullName = x.Customer.FullName,
                    EndDateOfInsurancePolicy = x.EndDateOfInsurancePolicy.ToShamsi(),
                    StartDateOfInsurancePolicy = x.StartDateOfInsurancePolicy.ToShamsi()
                })

                .ToListAsync()
        };
    }

    public void AddInsured(Insured insured)
    {
        _context.Add(insured);
        _context.SaveChanges();
    }

    public void AddInsuredInstallmentRange(List<InsuredInstallment> insuredInstallments)
    {
        _context.AddRange(insuredInstallments);
        _context.SaveChanges();
    }
}