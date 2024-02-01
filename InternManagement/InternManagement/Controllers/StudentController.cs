using InternManagement.DTOs.Student;
using InternManagement.Extensions;
using InternManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternManagement.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly InternManagementContext _context;

        public StudentController(ILogger<StudentController> logger, InternManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("list")]
        public IActionResult List([FromQuery] int pageSize, [FromQuery] int pageIndex)
        {
            if (pageSize == 0 || pageIndex == 0)
            {
                pageIndex = 1;
                pageSize = 10;
            }
            var students = _context.Students.Skip((pageIndex - 1)*pageSize).Take(pageSize).ToList();
            return View(students);
        }

        [HttpGet("detail")]
        public IActionResult Detail([FromQuery] int id)
        {
            var student = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            return View(student);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentBindingModel model)
        {
            try
            {
                if (model == null)
                {
                    return View();
                }

                var classOutput = ApplicationConfig.GetClass();

                var student = new Student()
                {
                    UserName = model.Name,
                    Password = model.Password,
                    Address = model.Address,
                    Email = model.Email,
                    Phone = model.Phone,
                    SubPhone = model.SubPhone,
                    ClassId = classOutput.FirstOrDefault(x => x.Id == model.ClassId).Name,
                    Identity = model.Identity,
                    Birthday = model.Birthday,
                    CreatedDate = DateTime.Now
                };

                _context.Add(student);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Cập nhật thành công thông tin sinh viên";

                return RedirectToAction("list"); // Redirect to the desired view
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
