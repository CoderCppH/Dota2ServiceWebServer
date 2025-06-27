using Dota2Service;
using Dota2Service.Model;
using Dota2Service.UserService.Hash;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dota2Service.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("UserTables");
            builder.HasKey(u => u.Id);
            builder
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            builder.HasData(new UserModel 
            {
                Id = 1, 
                Firstname = "Admin", 
                Lastname = "System", 
                Email = "coder.cpp.h@gmail.com", 
                Phone = "89911481427", 
                RoleId = 2, 
                DateCreated = DateTime.UtcNow, 
                Token = UserService.Token.TokenGenerator.GenerateToken(),  
                Password = PasswordHash.EncryptorPassword("Admin2005@",PasswordHash.GeneratorSlat())
            });
        }
    }
}
