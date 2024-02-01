using InternManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternManagement.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly ILogger<EvaluationController> _logger;
        private readonly InternManagementContext _context;

        public EvaluationController(ILogger<EvaluationController> logger, InternManagementContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
