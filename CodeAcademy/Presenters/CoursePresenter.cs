using CodeAcademy.Models;
using CodeAcademy.Views;

namespace CodeAcademy.Presenters
{
    public class CoursePresenter
    {
        private readonly ICourseView _view;
        private Course _course;

        public CoursePresenter(ICourseView view, Course course)
        {
            _view = view;
            _course = course;

            _view.LessonCompleted += OnLessonCompleted;
            _view.LoadCourse(course);
            UpdateProgress();
        }

        private void OnLessonCompleted(Lesson lesson)
        {
            lesson.IsCompleted = true;
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            _view.UpdateProgress(_course.Progress, _course.CompletedLessons, _course.Lessons.Count);
        }
    }
}