using Crm.Application.Utilities;
using Crm.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Infra.Data.Seeders;

public class UserSeeder : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new List<User>()
        {
            new User(){UserId = 1,Name = "سید محمد رضا آزاد", UserName = "SuperAdmin",Password = SecurityHelper.GetSha256Hash("1qaz@WSX3edc"),IsActive = true,CreateDate = new DateTime(2022, 03, 02, 19, 56, 32, 968, DateTimeKind.Local).AddTicks(1379)}
        });
    }
}