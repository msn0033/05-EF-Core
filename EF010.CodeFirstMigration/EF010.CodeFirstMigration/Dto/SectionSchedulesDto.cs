using EF010.CodeFirstMigration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EF010.CodeFirstMigration.Dto
{
    public class SectionSchedulesDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public string SectionName { get; set; } = null!;
        public string InstructorName { get; set; } = null!;
        public string? ScheduleTitle { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public bool SUN { get; set; }
        public bool MON { get; set; }
        public bool TUE { get; set; }
        public bool WED { get; set; }
        public bool THU { get; set; }
        public bool FRI { get; set; }
        public bool SAT { get; set; }


        public override string ToString()
        {

            var x =$"{Id} :{CourseName}\t :{SectionName}\t : {InstructorName}\t : {ScheduleTitle}\t : {StartTime}\t : {EndTime}\t : {SUN}\t : {MON}" ;
            return x;
        }
    }
}
