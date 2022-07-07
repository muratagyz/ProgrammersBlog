using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(20);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(250);
            builder.HasOne<Role>(x => x.Role).WithMany(y => y.Users).HasForeignKey(z => z.RoleId);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.MotifiedByName).IsRequired();
            builder.Property(x => x.MotifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.MotifiedByName).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.ToTable("Users");

            builder.HasData(new User
            {
                Id = 1,
                RoleId = 1,
                FirstName = "Murat",
                LastName = "AĞYÜZ",
                UserName = "muratagyuz",
                Email = "muratagyuz@outlook.com",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                MotifiedByName = "InitialCreate",
                MotifiedDate = DateTime.Now,
                Description = "İlk Adım Kullanıcı",
                Note = "Admin Kullanıcısı",
                PasswordHash = Encoding.ASCII.GetBytes("49d239e33fec238b289ce84ff2cc2c79"),
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU"
            });
        }
    }
}
