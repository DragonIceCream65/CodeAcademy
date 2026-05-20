namespace CodeAcademy.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int DurationMinutes { get; set; }
        public bool IsCompleted { get; set; }

        public Lesson(int id, string title, string content, int duration)
        {
            Id = id;
            Title = title;
            Content = content;
            DurationMinutes = duration;
            IsCompleted = false;
        }
    }
}