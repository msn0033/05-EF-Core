using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF010.CodeFirstMigration.Entities
{
    public class SectionSchedule
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int ScheduleId { get; set; }
        public Section Sections { get; set; } = null!;
        public Schedule Schedules { get; set; } = null!;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}
