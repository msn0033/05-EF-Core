// See https://aka.ms/new-console-template for more information
using EF010.CodeFirstMigration.Data;
using EF010.CodeFirstMigration.Dto;
using EF010.CodeFirstMigration.Entities;
using System.Runtime.CompilerServices;

var app = new AppDbContext();
var ee = app.SectionSchedules.Select(x => new SectionSchedulesDto
{
    Id = x.Sections.Id,
    CourseName = x.Sections.Course.CourseName!,
    SectionName = x.Sections.SectionName!,
    InstructorName = x.Sections.Instructor!.FName + " " + x.Sections.Instructor.LName,
    ScheduleTitle=x.Schedules.Title!,
    StartTime=x.EndTime.ToString(@"hh\:mm"),
    EndTime=x.EndTime.ToString(@"hh\:mm"),
    SUN=x.Schedules.SUN,
    MON = x.Schedules.MON,
    TUE = x.Schedules.TUE,
    WED = x.Schedules.WED,
    THU = x.Schedules.THU,
    FRI = x.Schedules.FRI,
    SAT = x.Schedules.SAT,
}
);
var ee1 = app.Sections.Select(w =>new SectionDto {
    Id=w.Id,
    SectionName=w.SectionName,
    Course=w.Course,
    Instructor = w.Instructor,
    Schedule= w.Schedules.FirstOrDefault(),
    SectionSchedule= w.SectionSchedules.FirstOrDefault(),
    Students= w.Students,
});

Console.WriteLine(Header());
foreach (var e in ee1)
    Console.WriteLine(e);
//foreach (var c in ee)
//{
//    Console.WriteLine(c);
//}
static string Header()
{
    return "| Id |  Course      | Section | Instructor           | Schedule       | Time Slot     | SUN | MON | TUE | WED | THU | FRI | SAT |";

}