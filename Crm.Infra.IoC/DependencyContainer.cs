using Crm.Application.Interfaces;
using Crm.Application.Services;
using Crm.Domain.Interfaces;
using Crm.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Crm.Infra.IoC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection service)
    {

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
        

        service.AddScoped<IInsuredService, InsuredService>();
        service.AddScoped<IInsuredRepository, InsuredRepository>();
        

        service.AddScoped<IRatioService, RatioService>();
        service.AddScoped<IRatioRepository, RatioRepository>();


        service.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}