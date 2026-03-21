using Microsoft.AspNetCore.Mvc;
using AS_Taranenko_lab1_gr1.Models;
using System.Linq;

namespace AS_Taranenko_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Artem",
                    Surname = "Taranenko",
                    Index = 139029,
                    BirthDate = new DateTime(2007, 1, 28),
                    Major = "Computer Science"
                },

                new Student
                {
                    Id = 2,
                    Name = "Marek",
                    Surname = "Polak",
                    Index = 139028,
                    BirthDate = new DateTime(2005, 11, 24),
                    Major = "Business Administration"
                },

                new Student
                {
                    Id = 3,
                    Name = "Jan",
                    Surname = "Kowalski",
                    Index = 139128,
                    BirthDate = new DateTime(2006, 6, 22),
                    Major = "Logistics"
                }
            };
        }

        public IActionResult Index()
        {
            var students = GetStudents();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = GetStudents().FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
