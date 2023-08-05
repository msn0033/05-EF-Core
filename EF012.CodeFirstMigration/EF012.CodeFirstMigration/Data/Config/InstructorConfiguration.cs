using EF012.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF012.CodeFirstMigration.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();
            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

           #region relationShip

            builder.HasOne(x => x.Office)
                  .WithOne(x => x.Instructor)
                  .HasForeignKey<Instructor>(x => x.OfficeId)
                  .IsRequired(false);//optinal
            #endregion

            builder.ToTable("Instructors");
            builder.HasData(LoadInstructors());


        }

        private ICollection<Instructor> LoadInstructors()
        {
            return new List<Instructor>
          {
              new Instructor {Id=1,FName="Ahmed",LName="Abdullah",OfficeId=1},
              new Instructor {Id=2,FName="Yasmeen",LName="Mohammed",OfficeId=2},
              new Instructor {Id=3,FName="Khalid",LName="Hassan",OfficeId=3},
              new Instructor {Id=4,FName="Nadia",LName="Ali",OfficeId=4},
              new Instructor {Id=5,FName="Omar",LName="Ibrahim",OfficeId=5},
          };
        }
    }
}
