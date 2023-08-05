using EF012.CodeFirstMigration.Entities;
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
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.SectionName)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();

          

            #region RelationShip

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseId)
                .IsRequired();//CaseCade

            builder.HasOne(x => x.Instructor)
                .WithMany(x => x.Section)
                .HasForeignKey(x => x.InstrutorId)
                .IsRequired(false);//optional

            builder.HasOne(x => x.Schedule)
                .WithMany(s => s.Sections)
                .HasForeignKey(x => x.ScheduleId)
                .IsRequired();



            builder.HasMany(x => x.Students)
                .WithMany(s => s.Sections)
                .UsingEntity<Enrollment>();
                

            builder.OwnsOne(x => x.TimeSlot, ts => {
                ts.Property(p => p.StartTime).HasColumnType("time").HasColumnName("StartTime");
                ts.Property(p => p.EndTime).HasColumnType("time").HasColumnName("EndTime");
            });




            #endregion

            //builder.HasIndex(x => x.CourseId);
            //builder.HasIndex(x => x.InstrutorId);
            builder.ToTable("Sections");
            builder.HasData(LoadSection());

        }

        private ICollection<Section> LoadSection()
        {
            return new List<Section>()
            {
                new Section() {Id=1,SectionName="S_MA1",CourseId=1,InstrutorId=1 ,ScheduleId=1 },
                new Section() {Id=2,SectionName="S_MA2",CourseId=1,InstrutorId=2 ,ScheduleId=3 },
                new Section() {Id=3,SectionName="S_PH1",CourseId=2,InstrutorId=1 ,ScheduleId=4 },
                new Section() {Id=4,SectionName="S_PH2",CourseId=2,InstrutorId=3 ,ScheduleId=1 },
                new Section() {Id=5,SectionName="S_CH1",CourseId=3,InstrutorId=2 ,ScheduleId=1 },
                new Section() {Id=6,SectionName="S_CH2",CourseId=3,InstrutorId=3 ,ScheduleId=2 },
                new Section() {Id=7,SectionName="S_BI1",CourseId=4,InstrutorId=4 ,ScheduleId=3 },
                new Section() {Id=8,SectionName="S_BI2",CourseId=4,InstrutorId=5 ,ScheduleId=4 },
                new Section() {Id=9,SectionName="S_CS1",CourseId=5,InstrutorId=4 ,ScheduleId=4 },
                new Section() {Id=10,SectionName="S_CS2",CourseId=5,InstrutorId=5,ScheduleId=3 },
                new Section() {Id=11,SectionName="S_CS3",CourseId=5,InstrutorId=4,ScheduleId=5 },
            };
        }
    }
}
