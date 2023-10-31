using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewForPartialView.Models;
using NewForPartialView.Utility;
using Newtonsoft.Json;
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
            List<Stud> model = _db.Studs.Include(s => s.ImageUrl).ToList();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_StudPartialView", model);
            }


            return View("Student_Information");
        }

        public IActionResult AddDataToTable()
        {
         return View("AddDataToTable");

        }



        [HttpPost]
        public IActionResult AddStud([FromForm] Stud student, List<IFormFile> images)
        {
            if (ModelState.IsValid)
            {
                _db.Studs.Add(student);
                _db.SaveChanges();

            if (images != null && images.Count > 0)
            {
                student.ImageUrl = new List<StudentImage>();

                string studentFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/Student", student.Id.ToString());

                if (!Directory.Exists(studentFolder))
                {
                    Directory.CreateDirectory(studentFolder);
                }

                foreach (var image in images)
                {
                    if (image.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                        string filePath = Path.Combine(studentFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(fileStream);
                        }

                        student.ImageUrl.Add(new StudentImage
                        {
                            Url = $"/images/Student/{student.Id}/{uniqueFileName}"
                        });
                    }
                }

                _db.SaveChanges();
                }

                return Content("Success");
            }

            return BadRequest("Invalid data.");
        }


        [HttpPost]
        public IActionResult UpdateStud([FromForm] Stud student, List<IFormFile> images)
        {
          
            if (ModelState.IsValid)
            {
             


                var existingStudent = _db.Studs
     .Include(s => s.ImageUrl)
     .FirstOrDefault(s => s.Id == student.Id);

          
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Roll = student.Roll;
                existingStudent.Address = student.Address;
                existingStudent.City = student.City;

                if (existingStudent.ImageUrl == null)
                {
                    existingStudent.ImageUrl = new List<StudentImage>(); // Initialize if null
                }

                existingStudent.ImageUrl.Clear();

                string studentFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/Student", existingStudent.Id.ToString());


                if (!Directory.Exists(studentFolder))
                {
                    Directory.CreateDirectory(studentFolder);
                }

                foreach (var image in images)
                {
                    if (image.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                        string filePath = Path.Combine(studentFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(fileStream);
                        }

                        existingStudent.ImageUrl.Add(new StudentImage
                        {
                            Url = $"/images/Student/{existingStudent.Id}/{uniqueFileName}"
                        });
                    }
                }

                _db.SaveChanges();

                return Content("Success");
            }
            else
            {
                Console.WriteLine("Student not found with Id: " + student.Id);
            }
            }
            return Content("Success");
        }



        [HttpGet]
        public IActionResult GetStudent(int id)
        {
            var student = _db.Studs
                .Include(s => s.ImageUrl) // Include related StudentImage data
                .FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                var studentData = new
                {
                    id = student.Id,
                    name = student.Name,
                    roll = student.Roll,
                    address = student.Address,
                    city = student.City,
                    imageUrl = student.ImageUrl.Select(image => image.Url).ToList() // Extract URLs from StudentImage objects
                };

                return Json(studentData);
            }

            return Json(null); // Handle case where the student is not found
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