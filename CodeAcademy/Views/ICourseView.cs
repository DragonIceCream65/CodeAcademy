using CodeAcademy.Models;

namespace CodeAcademy.Views
{
    public interface ICourseView
    {
        void LoadCourse(Course course);
        void UpdateProgress(float progress, int completed, int total);
        event System.Action<Lesson> LessonSelected;
        event System.Action<Lesson> LessonCompleted;
    }
}