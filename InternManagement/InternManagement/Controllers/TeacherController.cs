using InternManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternManagement.Controllers
{
    [Route("teacher")]
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly InternManagementContext _context;

        public TeacherController(ILogger<TeacherController> logger, InternManagementContext context)
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
            var students = _context.Teachers.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return View(students);
        }

        [HttpGet("detail")]
        public IActionResult Detail([FromQuery] int id)
        {
            var student = _context.Teachers.Where(x => x.Id == id).FirstOrDefault();
            return View(student);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Teacher model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                _context.Teachers.Add(model);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Success";

                return RedirectToAction("list"); // Redirect to the desired view
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
