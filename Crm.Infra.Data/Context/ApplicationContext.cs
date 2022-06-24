using System.Reflection;
using System.Security;
using Crm.Application.Utilities;
using Crm.Domain.Enum.TypeSystem;
using Crm.Domain.Models;
using Crm.Domain.Models.Area;
using Crm.Domain.Models.Customer;
using Crm.Domain.Models.Installment;
using Crm.Domain.Models.Insurance;
using Crm.Domain.Models.MaritalStatus;
using Crm.Domain.Models.PaymentMethod;
using Crm.Domain.Models.Permissions;
using Crm.Domain.Models.User;
using Crm.Infra.Data.Seeders;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infra.Data.Context;

public class ApplicationContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationContext(DbContextOptions<ApplicationContext> options, IHttpContextAccessor httpContextAccessor):base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<Permission> Permission { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }


    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }


    public DbSet<MaritalStatus> MaritalStatus { get; set; }
    public DbSet<Insurance> Insurance { get; set; }
    public DbSet<Insured> Insureds { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Installment> Installments { get; set; }
    public DbSet<TermInsurance> TermInsurances { get; set; }

    public DbSet<Customer> Customers { get; set; }


    public DbSet<Province> Provinces { get; set; }
    public DbSet<Township> Townships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;



        var assembly = typeof(PermissionSeeder).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);

        int userId = _httpContextAccessor.HttpContext.User.GetUserId();

        modelBuilder.Entity<Role>().HasQueryFilter(c => c.DeleteDate == null);
        modelBuilder.Entity<User>().HasQueryFilter(c => c.DeleteDate == null);

        modelBuilder.Entity<MaritalStatus>().HasQueryFilter(c => c.DeleteDate == null && c.UserId == userId);
        modelBuilder.Entity<Insurance>().HasQueryFilter(c => c.DeleteDate == null && c.UserId == userId);
        modelBuilder.Entity<PaymentMethod>().HasQueryFilter(c => c.DeleteDate == null && c.UserId == userId);
        modelBuilder.Entity<Customer>().HasQueryFilter(c => c.DeleteDate == null && c.UserId == userId);
        modelBuilder.Entity<Installment>().HasQueryFilter(c => c.DeleteDate == null && c.UserId == userId);
        modelBuilder.Entity<TermInsurance>().HasQueryFilter(c => c.DeleteDate == null && c.UserId == userId);
        modelBuilder.Entity<Insured>().HasQueryFilter(c => c.DeleteDate == null && c.UserId == userId);

    }

    public override int SaveChanges()
    {
        _cleanString();
        return base.SaveChanges();
    }


    private void _cleanString()
    {
        var changedEntities = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
        foreach (var item in changedEntities)
        {
            var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

            foreach (var property in properties)
            {
                var propName = property.Name;
                var val = (string)property.GetValue(item.Entity, null)!;

                if (val.HasValue())
                {
                    var newVal = val.Fa2En().FixPersianChars();
                    if (newVal == val)
                        continue;
                    property.SetValue(item.Entity, newVal, null);
                }
            }
        }
    }

}