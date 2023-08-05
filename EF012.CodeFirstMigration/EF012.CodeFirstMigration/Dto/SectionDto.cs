using EF012.CodeFirstMigration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF012.CodeFirstMigration.Dto
{
    internal class SectionDto
    {
        public int Id { get; set; }
        public string? SectionName { get; set; }
       
        public Course Course { get; set; } = null!;

        public Instructor? Instructor { get; set; }

        public Schedule? Schedule { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }



        public override string ToString()
        {
            string SUN = Schedule!.SUN ? " X " : "  ";
            string MON = Schedule!.MON ? " X " : "  ";
            string TUE = Schedule!.TUE ? " X " : "  ";
            string WED = Schedule!.WED ? " X " : "  ";
            string THU = Schedule!.THU ? " X " : "  ";
            string FRI = Schedule!.FRI ? " X " : "  ";
            string SAT = Schedule!.SAT ? " X " : "  ";
           var x = $"| {Id.ToString().PadLeft(2, '0')} | {Course.CourseName,-12} | {SectionName,-7} | {Instructor?.FName + " " + Instructor?.LName,-20} | {Schedule?.Title?.ToString()?.PadRight(14)} | " +
                $"{StartTime.ToString("hh\\:mm")} - {EndTime.ToString("hh\\:mm").PadRight(5)} "+
                $"| {SUN.PadRight(3)} | {MON.PadRight(3)} | {TUE.PadRight(3)} | {WED.PadRight(3)} | {THU.PadRight(3)} | {FRI.PadRight(3)} | {SAT.PadRight(3)} |";
         //   var x = "";
            return x;
        }

    }
}
