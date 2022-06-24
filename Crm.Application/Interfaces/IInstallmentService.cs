using Crm.Domain.Models.Installment;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Interfaces;

public interface IInstallmentService
{
    List<Installment> GetAllInstallment();
    Installment? GetInstallmentById(int installmentId);
    void AddInstallment(Installment installment);
    void UpdateInstallment(Installment installment);
    void DeleteInstallment(int installmentId);
    bool CheckCodeInstallment(int installmentId, int code);
    List<SelectListItem> GetTypeSystem();
    List<SelectListItem> GetInstallment();
}