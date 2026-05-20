using System.Collections.Generic;
using CodeAcademy.Models;

namespace CodeAcademy.Views
{
    public interface IMainView
    {
        string SearchText { get; }
        string SelectedCategory { get; }
        void DisplayCourses(List<Course> courses);
        void ShowMessage(string message);
        event System.EventHandler SearchChanged;
        event System.EventHandler CategoryChanged;
        event System.Action<Course> CourseSelected;
    }
}