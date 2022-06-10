using Crm.Domain.Models.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Infra.Data.Seeders
{
    public class PermissionSeeder : IEntityTypeConfiguration<Permission>
    {
        //سطح دسترسی
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(new List<Permission>()
            {
                new Permission(){PermissionId = 1,Title = "داشبورد",ParentId = null},
                new Permission(){PermissionId = 2,Title = "تنظییمات",ParentId = null},

                new Permission(){PermissionId = 3,Title = "کاربران",ParentId = 2},
                new Permission(){PermissionId = 4,Title = "افزودن کاربر",ParentId = 3},
                new Permission(){PermissionId = 5,Title = "ویرایش کاربر ",ParentId = 3},
                new Permission(){PermissionId = 6,Title = "حذف کاربر",ParentId = 3}, 
                
                new Permission(){PermissionId = 7,Title = "سطح دسترسی",ParentId = 2},
                new Permission(){PermissionId = 8,Title = "افزودن سطح دسترسی",ParentId = 7},
                new Permission(){PermissionId = 9,Title = "ویرایش سطح دسترسی",ParentId = 7},
                new Permission(){PermissionId = 10,Title = "حذف سطح دسترسی",ParentId = 7},

                new Permission(){PermissionId =11,Title = "تعاریف",ParentId = null},

                new Permission(){PermissionId = 12,Title = "وضعیت تاهل",ParentId = 11},
                new Permission(){PermissionId = 13,Title = "افزودن وضعیت تاهل",ParentId = 12},
                new Permission(){PermissionId = 14,Title = "ویرایش وضعیت تاهل ",ParentId = 12},
                new Permission(){PermissionId = 15,Title = "حذف وضعیت تاهل",ParentId = 12},


                new Permission(){PermissionId = 16,Title = "مشتریان",ParentId = null},
                new Permission(){PermissionId = 17,Title = "افزودن مشتری",ParentId = 16},
                new Permission(){PermissionId = 18,Title = "ویرایش مشتری ",ParentId = 16},
                new Permission(){PermissionId = 19,Title = "حذف مشتری",ParentId = 16},


                new Permission(){PermissionId = 20,Title = "بیمه",ParentId = 11},
                new Permission(){PermissionId = 21,Title = "افزودن بیمه",ParentId = 20},
                new Permission(){PermissionId = 22,Title = "ویرایش بیمه ",ParentId = 20},
                new Permission(){PermissionId = 23,Title = "حذف بیمه",ParentId = 20},


                new Permission(){PermissionId = 24,Title = "روش پرداخت",ParentId = 11},
                new Permission(){PermissionId = 25,Title = "افزودن روش پرداخت",ParentId = 24},
                new Permission(){PermissionId = 26,Title = "ویرایش روش پرداخت ",ParentId = 24},
                new Permission(){PermissionId = 27,Title = "حذف روش پرداخت",ParentId = 24},
                

                new Permission(){PermissionId = 28,Title = "قسط",ParentId = 11},
                new Permission(){PermissionId = 29,Title = "افزودن قسط",ParentId = 28},
                new Permission(){PermissionId = 30,Title = "ویرایش قسط ",ParentId = 28},
                new Permission(){PermissionId = 31,Title = "حذف قسط",ParentId = 28},


                new Permission(){PermissionId = 32,Title = "مدت بیمه نامه",ParentId = 11},
                new Permission(){PermissionId = 33,Title = "افزودن مدت بیمه نامه",ParentId = 32},
                new Permission(){PermissionId = 34,Title = "ویرایش مدت بیمه نامه ",ParentId = 32},
                new Permission(){PermissionId = 35,Title = "حذف مدت بیمه نامه",ParentId = 32},
            });
        }
    }
}