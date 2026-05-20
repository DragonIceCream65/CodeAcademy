using System.Collections.Generic;
using System.Linq;

namespace CodeAcademy.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public CourseCategory Category { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public List<Lesson> Lessons { get; set; }
        public string AccentColor { get; set; }

        public Course()
        {
            Lessons = new List<Lesson>();
        }

        public int TotalMinutes => Lessons.Sum(l => l.DurationMinutes);
        public int CompletedLessons => Lessons.Count(l => l.IsCompleted);
        public float Progress => Lessons.Count == 0 ? 0 : (float)CompletedLessons / Lessons.Count * 100;
        public string DifficultyLabel => Difficulty.ToString();
        public string CategoryLabel => Category.ToString();
    }
}