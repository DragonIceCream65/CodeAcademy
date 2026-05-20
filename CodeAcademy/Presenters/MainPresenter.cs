using System.Collections.Generic;
using System.Linq;
using CodeAcademy.Data;
using CodeAcademy.Models;
using CodeAcademy.Views;

namespace CodeAcademy.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly CourseRepository _repository;
        private List<Course> _allCourses;

        public MainPresenter(IMainView view, CourseRepository repository)
        {
            _view = view;
            _repository = repository;
            _allCourses = _repository.GetAllCourses();

            _view.SearchChanged += OnSearchChanged;
            _view.CategoryChanged += OnCategoryChanged;
        }

        public void LoadCourses()
        {
            _view.DisplayCourses(_allCourses);
        }

        private void OnSearchChanged(object sender, System.EventArgs e)
        {
            FilterCourses();
        }

        private void OnCategoryChanged(object sender, System.EventArgs e)
        {
            FilterCourses();
        }

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