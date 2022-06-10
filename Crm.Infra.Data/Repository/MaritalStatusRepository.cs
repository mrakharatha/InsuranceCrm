using Crm.Domain.Interfaces;
using Crm.Domain.Models.MaritalStatus;
using Crm.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Infra.Data.Repository;

public class MaritalStatusRepository : IMaritalStatusRepository
{
    private readonly ApplicationContext _context;

    public MaritalStatusRepository(ApplicationContext context)
    {
        _context = context;
    }

    public List<MaritalStatus> GetAllMaritalStatus()
    {
        return _context.MaritalStatus
            .OrderByDescending(x=> x.MaritalStatusId)
            .ToList();
    }

    public MaritalStatus? GetMaritalStatusById(int maritalStatusId)
    {
        return _context.MaritalStatus.Find(maritalStatusId);
    }

    public void AddMaritalStatus(MaritalStatus maritalStatus)
    {
        _context.Add(maritalStatus);
        _context.SaveChanges();
    }

    public void UpdateMaritalStatus(MaritalStatus maritalStatus)
    {
        _context.Update(maritalStatus);
        _context.SaveChanges();
    }

    public bool CheckCodeMaritalStatus(int maritalStatusId, int code)
    {

        if (maritalStatusId == 0)
            return _context.MaritalStatus.Any(x => x.Code == code);

        return _context.MaritalStatus.Any(x => x.Code == code && x.MaritalStatusId != maritalStatusId);

    }

    public List<SelectListItem> GetMaritalStatus()
    {
        return _context.MaritalStatus
            .OrderByDescending(x => x.MaritalStatusId)
            .Select(x=> new SelectListItem()
            {
                Text = x.Title +" - "+x.Code,
                Value = x.MaritalStatusId.ToString()
            })
            .ToList();
    }
}