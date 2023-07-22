using EF010.CodeFirstMigration.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF010.CodeFirstMigration.Data.Config
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

            builder.ToTable("Sections");

            #region RelationShip

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseId)
                .IsRequired();//CaseCade

            builder.HasOne(x => x.Instructor)
                .WithMany(x => x.Section)
                .HasForeignKey(x => x.InstrutorId)
                .IsRequired(false);//optional

            builder.HasMany(x => x.Schedules)
                   .WithMany(x => x.Sections)
                   .UsingEntity<SectionSchedule>();

            builder.HasMany(sec => sec.Students)
                   .WithMany(stu => stu.Sections)
                   .UsingEntity<Enrollment>();



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
                new Section() {Id=1,SectionName="S_MA1",CourseId=1,InstrutorId=1},
                new Section() {Id=2,SectionName="S_MA2",CourseId=1,InstrutorId=2},
                new Section() {Id=3,SectionName="S_PH1",CourseId=2,InstrutorId=1},
                new Section() {Id=4,SectionName="S_PH2",CourseId=2,InstrutorId=3},
                new Section() {Id=5,SectionName="S_CH1",CourseId=3,InstrutorId=2},
                new Section() {Id=6,SectionName="S_CH2",CourseId=3,InstrutorId=3},
                new Section() {Id=7,SectionName="S_BI1",CourseId=4,InstrutorId=4},
                new Section() {Id=8,SectionName="S_BI2",CourseId=4,InstrutorId=5},
                new Section() {Id=9,SectionName="S_CS1",CourseId=5,InstrutorId=4},
                new Section() {Id=10,SectionName="S_CS2",CourseId=5,InstrutorId=5},
                new Section() {Id=11,SectionName="S_CS3",CourseId=5,InstrutorId=4},
            };
        }
    }
}
