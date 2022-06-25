using Crm.Application.Interfaces;
using Crm.Application.Utilities;
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

        var termInsurance = _termInsuranceService.GetTermInsuranceById(model.TermInsuranceId!.Value);

        var endDateOfInsurancePolicy = model.StartDateOfInsurancePolicy.ToDateTime().AddMonthsPersian(termInsurance!.Value!.Value);


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
        AddInsuredInstallment(insured.InsuredId,insured.InstallmentId!.Value,insured.InstallmentStartDate);
    }

    public void AddInsured(Insured insured)
    {
        _insuredRepository.AddInsured(insured);
    }

    public void AddInsuredInstallment(int insuredId, int installmentId, DateTime installmentStartDate)
    {
        var installment = _installmentService.GetInstallmentById(installmentId);

        var dateTimes = DateConvertor.GetInstallment(installmentStartDate,installment!.Value!.Value);

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

    public void DeleteInsuredInstallment(int insuredId)
    {
        _insuredRepository.DeleteInsuredInstallment(insuredId);
    }

    public void AddInsuredInstallmentRange(List<InsuredInstallment> insuredInstallments)
    {
        _insuredRepository.AddInsuredInstallmentRange(insuredInstallments);
    }

    public Insured? GetInsuredById(int insuredId)
    {
        return _insuredRepository.GetInsuredById(insuredId);
    }

    public EditInsuredViewModel? GetInsuredViewModel(int insuredId)
    {
        var insured = GetInsuredById(insuredId);

        if (insured == null)
            return null;

        return new EditInsuredViewModel()
        {
            AmountPerInstallment = insured.AmountPerInstallment,
            CapitalDeathFirstYear = insured.CapitalDeathFirstYear,
            CustomerId = insured.CustomerId,
            Description = insured.Description,
            FirstYearPremiumAmount = insured.FirstYearPremiumAmount,
            InstallmentId = insured.InstallmentId,
            InstallmentStartDate = insured.InstallmentStartDate.ToShamsi(),
            InsuranceId = insured.InsuranceId,
            InsuredId = insured.InsuredId,
            TermInsuranceId = insured.TermInsuranceId,
            PaymentMethodId = insured.PaymentMethodId,
            UserId = insured.UserId,
            StartDateOfInsurancePolicy = insured.StartDateOfInsurancePolicy.ToShamsi(),
            NumberCapitalDeathFirstYear = insured.CapitalDeathFirstYear.ToToman(),
            NumberFirstYearPremium = insured.FirstYearPremiumAmount.ToToman(),
            NumberPerInstallment = insured.AmountPerInstallment.ToToman()
        };
    }

    public void UpdateInsured(EditInsuredViewModel model)
    {
        var insured = GetInsuredById(model.InsuredId);

        if(insured==null)
            return;
        
        var termInsurance = _termInsuranceService.GetTermInsuranceById(model.TermInsuranceId!.Value);

        var endDateOfInsurancePolicy = model.StartDateOfInsurancePolicy.ToDateTime().AddMonthsPersian(termInsurance!.Value!.Value);


        insured.UserId = model.UserId;
        insured.CustomerId = model.CustomerId;
        insured.InstallmentId = model.InstallmentId;
        insured.PaymentMethodId = model.PaymentMethodId;
        insured.TermInsuranceId = model.TermInsuranceId;
        insured.InsuranceId = model.InsuranceId;
        insured.FirstYearPremiumAmount = model.FirstYearPremiumAmount;
        insured.InstallmentStartDate = model.InstallmentStartDate.ToDateTime();
        insured.AmountPerInstallment = model.AmountPerInstallment;
        insured.CapitalDeathFirstYear = model.CapitalDeathFirstYear;
        insured.StartDateOfInsurancePolicy = model.StartDateOfInsurancePolicy.ToDateTime();
        insured.EndDateOfInsurancePolicy = endDateOfInsurancePolicy;
        insured.Description = model.Description;


        UpdateInsured(insured);
        DeleteInsuredInstallment(insured.InsuredId);
        AddInsuredInstallment(insured.InsuredId, insured.InstallmentId!.Value, insured.InstallmentStartDate);
    }

    public void UpdateInsured(Insured insured)
    {
        insured.UpdateDate=DateTime.Now;
        _insuredRepository.UpdateInsured(insured);
    }

    public void DeleteInsured(int insuredId, int userId)
    {
        var insured = GetInsuredById(insuredId);

        if (insured == null)
            return;

        insured.UserId = userId;
        insured.DeleteDate=DateTime.Now;

        UpdateInsured(insured);
        DeleteInsuredInstallment(insured.InsuredId);
    }

    public List<InsuredInstallmentsViewModel> GetInsuredInstallmentsByInsuredId(int insuredId)
    {
        return _insuredRepository.GetInsuredInstallmentsByInsuredId(insuredId);
    }
}