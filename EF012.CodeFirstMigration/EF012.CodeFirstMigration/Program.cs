// See https://aka.ms/new-console-template for more information
using EF012.CodeFirstMigration.Data;
using EF012.CodeFirstMigration.Dto;
using EF012.CodeFirstMigration.Entities;
using System.Runtime.CompilerServices;

var app = new AppDbContext();

try
{
    //var StartTime= DateTime.Now;
    //var s1 = new Section {
    //    Id = 12,
    //    SectionName = "S_MA20",
    //    CourseId = 4,
    //    InstrutorId = 4,
    //    ScheduleId = 4,
    //    StartTime= TimeSpan.Parse("08:00:00"),
    //    EndTime= TimeSpan.Parse("10:00:00")

    //};
    
    //app.Sections.Add(s1);
    //await app.SaveChangesAsync();
    var ee1 = app.Sections.Select(w => new SectionDto
    {
        Id = w.Id,
        SectionName = w.SectionName,
        Course = w.Course,
        Instructor = w.Instructor,
        Schedule = w.Schedule,
        StartTime=w.TimeSlot.StartTime,
        EndTime=w.TimeSlot.EndTime,

    });
    Console.WriteLine(Header());
    foreach (var e in ee1)
        Console.WriteLine(e);
}
catch (Exception)
{

	throw;
}





static string Header()
{
    return "| Id |  Course      | Section | Instructor           | Schedule       | Time Slot     | SUN | MON | TUE | WED | THU | FRI | SAT |";

}