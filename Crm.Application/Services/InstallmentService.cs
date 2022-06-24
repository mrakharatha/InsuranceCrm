using Crm.Application.Interfaces;
using Crm.Application.Utilities;
using Crm.Domain.Enum.TypeSystem;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Installment;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Services;

public class InstallmentService: IInstallmentService
{
    private readonly IInstallmentRepository _installmentRepository;

    public InstallmentService(IInstallmentRepository installmentRepository)
    {
        _installmentRepository = installmentRepository;
    }

    public List<Installment> GetAllInstallment()
    {
        return _installmentRepository.GetAllInstallment();
    }

    public Installment? GetInstallmentById(int installmentId)
    {
        return _installmentRepository.GetInstallmentById(installmentId);
    }

    public void AddInstallment(Installment installment)
    {
        _installmentRepository.AddInstallment(installment);
    }

    public void UpdateInstallment(Installment installment)
    {
        installment.UpdateDate=DateTime.Now;
        _installmentRepository.UpdateInstallment(installment);
    }

    public void DeleteInstallment(int installmentId)
    {
        var installment = GetInstallmentById(installmentId);

        if(installment == null)
            return;


        installment.DeleteDate=DateTime.Now;
        UpdateInstallment(installment);
    }

    public bool CheckCodeInstallment(int installmentId, int code)
    {
        return _installmentRepository.CheckCodeInstallment(installmentId, code);
    }

    public List<SelectListItem> GetTypeSystem()
    {
        var list = new List<SelectListItem> {new SelectListItem(){Value =null,Text = "لطفا انتخاب کنید"}};
        list.AddRange(from TypeSystem val in Enum.GetValues(typeof(TypeSystem)) select new SelectListItem() {Value = val.ToString(), Text = val.ToDisplay()});
        return list;
    }

    public List<SelectListItem> GetInstallment()
    {
        return _installmentRepository.GetInstallment();
    }
}