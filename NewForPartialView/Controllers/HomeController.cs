using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewForPartialView.Models;
using NewForPartialView.Utility;
using System.Diagnostics;

namespace NewForPartialView.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employee()
        {
            return View();
        }
        [Authorize(Roles = SD.Role_Admin)]

        public IActionResult Student_Information()
        {
            List<Stud> model = _db.Studs.ToList();


            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_StudPartialView", model);
            }


            return View("Student_Information");
        }
        [HttpPost]
        public IActionResult AddStud([FromForm] Stud student, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/Student");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    student.ImageUrl = "/images/Student/" + uniqueFileName;
                }

                _db.Studs.Add(student);
                _db.SaveChanges();
                return Json(student);
            }

            return BadRequest("Invalid data.");
        }

        [HttpPost]
        public IActionResult UpdateStud([FromBody] Stud student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = _db.Studs.FirstOrDefault(s => s.Id == student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Roll = student.Roll;
                    existingStudent.Address = student.Address;
                    existingStudent.City = student.City;

                    _db.Studs.Update(existingStudent);
                    _db.SaveChanges();
                    return Json(existingStudent);
                }
            }
            return BadRequest("Invalid data.");
        }

        [HttpPost]
        public IActionResult DeleteStud(int id)
        {
            var student = _db.Studs.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _db.Studs.Remove(student);
                _db.SaveChanges();
                return Json(new { id });
            }
            return BadRequest("Student not found.");
        }

        public IActionResult Studs()
        {
            List<Stud> studs = _db.Studs.ToList();

            return View(studs);
        }

        public IActionResult Students()
        {
            List<Student> students = new List<Student>()
            {
            new Student() { Id=101,Name="Viraj"},
            new Student() { Id = 102, Name = "Mahesh" },
            new Student() { Id = 103, Name = "Shubham" }

            };
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}