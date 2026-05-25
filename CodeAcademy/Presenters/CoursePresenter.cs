using CodeAcademy.Models;
using CodeAcademy.Views;

namespace CodeAcademy.Presenters
{

    /// Presenter encargado de controlar
    /// el progreso de un curso.
    public class CoursePresenter
    {
        // Vista del curso actual
        private readonly ICourseView _view;

        // Información del curso
        private Curso _course;


        /// Inicializa el presenter del curso.
        /// Carga la información y controla el progreso.
        /// </summary>
        /// <param name="view">Vista del curso</param>
        /// <param name="course">Curso seleccionado</param>
        public CoursePresenter(ICourseView view, Curso course)
        {
            _view = view;
            _course = course;

            _view.LessonCompleted += OnLessonCompleted;
            _view.LoadCourse(course);
            UpdateProgress();
        }

        /// Marca una lección como completada
        /// y actualiza el progreso.
        private void OnLessonCompleted(Leccion lesson)
        {
            lesson.IsCompleted = true;
            UpdateProgress();
        }


        /// Actualiza el porcentaje de avance del curso.
        private void UpdateProgress()
        {
            _view.UpdateProgress(_course.Progress, _course.CompletedLessons, _course.Lessons.Count);
        }
    }
}