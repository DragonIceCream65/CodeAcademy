using System.Collections.Generic;
using System.Linq;
using CodeAcademy.Data;
using CodeAcademy.Models;
using CodeAcademy.Views;

namespace CodeAcademy.Presenters
{

    /// Presenter principal de la aplicación.
    /// Se encarga de conectar la vista con los datos de cursos.
    /// Controla la búsqueda, filtrado y visualización de cursos.
    public class MainPresenter
    {

        // Referencia a la interfaz principal
        private readonly IMainView _view;
        // Repositorio encargado de obtener los cursos
        private readonly CourseRepository _repository;
        // Lista que almacena todos los cursos disponible
        private List<Course> _allCourses;

        /// Constructor del presenter principal.
        /// Inicializa la vista, el repositorio y carga los cursos.
        /// Además, conecta los eventos de búsqueda y categorías.

        /// <param name="view">Vista principal de la aplicación</param>
        /// <param name="repository">Repositorio de cursos</param>
        public MainPresenter(IMainView view, CourseRepository repository)
        {
            _view = view;
            _repository = repository;
            _allCourses = _repository.GetAllCourses();

            _view.SearchChanged += OnSearchChanged;
            _view.CategoryChanged += OnCategoryChanged;
        }


        /// Muestra todos los cursos en la interfaz.
        public void LoadCourses()
        {
            _view.DisplayCourses(_allCourses);
        }


        /// Evento ejecutado cuando el usuario escribe en el buscador.
        private void OnSearchChanged(object sender, System.EventArgs e)
        {
            FilterCourses();
        }


        /// Evento ejecutado cuando el usuario cambia de categoría.
        private void OnCategoryChanged(object sender, System.EventArgs e)
        {
            FilterCourses();
        }

        /// Filtra los cursos según el texto de búsqueda
        /// y la categoría seleccionada.
        private void FilterCourses()
        {
            var filtered = _allCourses.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(_view.SearchText))
                filtered = filtered.Where(c =>
                    c.Title.ToLower().Contains(_view.SearchText.ToLower()) ||
                    c.Description.ToLower().Contains(_view.SearchText.ToLower()));

            if (_view.SelectedCategory != "Todos")
                filtered = filtered.Where(c =>
                    c.CategoryLabel == _view.SelectedCategory);

            _view.DisplayCourses(filtered.ToList());
        }
    }
}