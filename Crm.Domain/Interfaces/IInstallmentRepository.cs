﻿using Crm.Domain.Models.Installment;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Domain.Interfaces;

public interface IInstallmentRepository
{
    List<Installment> GetAllInstallment();
    Installment? GetInstallmentById(int installmentId);
    void AddInstallment(Installment installment);
    void UpdateInstallment(Installment installment);
    bool CheckCodeInstallment(int installmentId, int code);
    List<SelectListItem> GetInstallment();

}
