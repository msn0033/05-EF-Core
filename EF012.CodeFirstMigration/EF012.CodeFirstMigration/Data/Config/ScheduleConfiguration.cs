﻿using EF012.CodeFirstMigration.Entities;
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

            builder.ToTable("Schedules");

            builder.HasData(LoadSchedules());
        }

        private ICollection< Schedule> LoadSchedules()
        {
 
            return new List<Schedule> 
            {
                new Schedule { Id = 1,Title="Daily",SUN=true,MON=true,TUE=true,WED=true,THU=true,FRI=false,SAT=false},
                new Schedule { Id = 2,Title="DayAfterDay",SUN=true,MON=false,TUE=true,WED=false,THU=true,FRI=false,SAT=false},
                new Schedule { Id = 3,Title="Twice-a-Week",SUN=false,MON=true,TUE=false,WED=true,THU=false,FRI=false,SAT=false},
                new Schedule { Id = 4,Title="Weekend",SUN=false,MON=false,TUE=false,WED=false,THU=false,FRI=true,SAT=true},
                new Schedule { Id = 5,Title="Compact",SUN=true,MON=true,TUE=true,WED=true,THU=true,FRI=true,SAT=true},
            };
        }
    }
}