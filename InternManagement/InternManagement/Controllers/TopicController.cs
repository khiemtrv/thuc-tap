using InternManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternManagement.Controllers
{
    [Route("topic")]
    public class TopicController : Controller
    {
        private readonly ILogger<TopicController> _logger;
        private readonly InternManagementContext _context;

        public TopicController(ILogger<TopicController> logger, InternManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List([FromQuery] int pageSize,[FromQuery] int pageIndex)
        {
            var topics = await _context.Topics.Skip((pageIndex - 1)* pageSize).Take(pageSize).ToListAsync();
            return View(topics);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Topic request)
        {
            return View();
        }
    }
}
