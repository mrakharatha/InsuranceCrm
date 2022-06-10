using Crm.Application.Interfaces;
using Crm.Application.Services;
using Crm.Domain.Interfaces;
using Crm.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Infra.IoC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection service)
    {
        service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        service.AddScoped<IPermissionService, PermissionService>();
        service.AddScoped<IPermissionRepository, PermissionRepository>();

        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IUserRepository, UserRepository>();

        service.AddScoped<IMaritalStatusService, MaritalStatusService>();
        service.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();

        service.AddScoped<IInsuranceService, InsuranceService>();
        service.AddScoped<IInsuranceRepository, InsuranceRepository>();

        service.AddScoped<IPaymentMethodService, PaymentMethodService>();
        service.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();

        service.AddScoped<IInstallmentService, InstallmentService>();
        service.AddScoped<IInstallmentRepository, InstallmentRepository>();

        service.AddScoped<ITermInsuranceService, TermInsuranceService>();
        service.AddScoped<ITermInsuranceRepository, TermInsuranceRepository>();

        service.AddScoped<ICustomerService, CustomerService>();
        service.AddScoped<ICustomerRepository, CustomerRepository>();

        service.AddScoped<IAreaService, AreaService>();
        service.AddScoped<IAreaRepository, AreaRepository>();

    }
}