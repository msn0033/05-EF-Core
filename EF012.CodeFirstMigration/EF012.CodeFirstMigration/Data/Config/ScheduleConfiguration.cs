using EF012.CodeFirstMigration.Entities;
using EF012.CodeFirstMigration.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF012.CodeFirstMigration.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();
           

            builder.Property(x => x.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasConversion(s => s.ToString(), m =>(ScheduleEnum) Enum.Parse(typeof(ScheduleEnum), m));

            builder.ToTable("Schedules");

            builder.HasData(LoadSchedules());
        }

        private ICollection< Schedule> LoadSchedules()
        {
 
            return new List<Schedule> 
            {
                new Schedule { Id = 1,Title=ScheduleEnum.Daily,SUN=true,MON=true,TUE=true,WED=true,THU=true,FRI=false,SAT=false},
                new Schedule { Id = 2,Title=ScheduleEnum.DayAfterDay,SUN=true,MON=false,TUE=true,WED=false,THU=true,FRI=false,SAT=false},
                new Schedule { Id = 3,Title=ScheduleEnum.Twice_a_Week,SUN=false,MON=true,TUE=false,WED=true,THU=false,FRI=false,SAT=false},
                new Schedule { Id = 4,Title=ScheduleEnum.Weekend,SUN=false,MON=false,TUE=false,WED=false,THU=false,FRI=true,SAT=true},
                new Schedule { Id = 5,Title=ScheduleEnum.Compact,SUN=true,MON=true,TUE=true,WED=true,THU=true,FRI=true,SAT=true},
            };
        }
    }
}
