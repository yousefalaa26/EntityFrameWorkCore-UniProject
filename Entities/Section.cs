using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialMigration123.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string? SectionName { get; set; }
        public int CourseId { get; set; }// one to one with courses table
        public Course Course { get; set; }

        public int? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
