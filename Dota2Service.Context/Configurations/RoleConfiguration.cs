using Dota2Service.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Dota2Service.Context.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.ToTable("RoleTables");
            builder.HasKey(r => r.Id);

            builder.HasData(new RoleModel { Id = 1, NameRole = "Guest", AccessStatus = 0 });
            builder.HasData(new RoleModel { Id = 2, NameRole = "User", AccessStatus = 1 });
            builder.HasData(new RoleModel { Id = 3, NameRole = "Admin", AccessStatus = 2 });
        }
    }
}
