using Crm.Application.Interfaces;
using Crm.Domain.Convertors;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;

namespace Crm.Application.Services;

public class InsuredService: IInsuredService
{
    private readonly IInsuredRepository _insuredRepository;
    private readonly ITermInsuranceService _termInsuranceService;
    private readonly IInstallmentService _installmentService;
    public InsuredService(IInsuredRepository insuredRepository, ITermInsuranceService termInsuranceService, IInstallmentService installmentService)
    {
        _insuredRepository = insuredRepository;
        _termInsuranceService = termInsuranceService;
        _installmentService = installmentService;
    }

    public async Task<DtResult<InsuredViewModel>> GetData(DtParameters dtParameters)
    {
        var result = _insuredRepository.GetData(dtParameters);
        return await result;
    }

    public void AddInsured(AddInsuredViewModel model)
    {
        var termInsurance = _termInsuranceService.GetTermInsuranceById(model.TermInsuranceId.Value);

        var endDateOfInsurancePolicy = model.StartDateOfInsurancePolicy.ToDateTime().AddMonthsPersian(termInsurance.Value.Value);


        var insured = new Insured()
        {
            UserId = model.UserId,
            CustomerId = model.CustomerId,
            InstallmentId = model.InstallmentId,
            PaymentMethodId = model.PaymentMethodId,
            TermInsuranceId = model.TermInsuranceId,
            InsuranceId = model.InsuranceId,
            FirstYearPremiumAmount = model.FirstYearPremiumAmount,
            InstallmentStartDate = model.InstallmentStartDate.ToDateTime(),
            AmountPerInstallment = model.AmountPerInstallment,
            CapitalDeathFirstYear = model.CapitalDeathFirstYear,
            StartDateOfInsurancePolicy = model.StartDateOfInsurancePolicy.ToDateTime(),
            EndDateOfInsurancePolicy = endDateOfInsurancePolicy,
            Description = model.Description,

        };  

        AddInsured(insured);
        AddInsuredInstallment(insured.InsuredId,insured.InstallmentId.Value,insured.InstallmentStartDate);
    }

    public void AddInsured(Insured insured)
    {
        _insuredRepository.AddInsured(insured);
    }

    public void AddInsuredInstallment(int insuredId, int installmentId, DateTime installmentStartDate)
    {
        var installment = _installmentService.GetInstallmentById(installmentId);

        var dateTimes = DateConvertor.GetInstallment(installmentStartDate,installment.Value.Value);

        List<InsuredInstallment> insuredInstallments = new List<InsuredInstallment>();
        foreach (var dateTime in dateTimes)
        {
            insuredInstallments.Add(new InsuredInstallment()
            {
                InsuredId = insuredId,
                DateInstallment = dateTime
            });
        }
        AddInsuredInstallmentRange(insuredInstallments);
    }

    public void AddInsuredInstallmentRange(List<InsuredInstallment> insuredInstallments)
    {
        _insuredRepository.AddInsuredInstallmentRange(insuredInstallments);
    }
}