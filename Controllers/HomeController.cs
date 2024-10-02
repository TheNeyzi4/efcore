using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Services;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IServiceUsers? _serviceUsers;
        public HomeController(IServiceUsers? serviceUsers, UserContext? context)
        {
            _serviceUsers = serviceUsers;
            _serviceUsers.Context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_serviceUsers.Read());
        }

        [HttpGet("Get")]
        public JsonResult Get()
            => Json(_serviceUsers?.Read());
        [HttpGet("{id}")]
        public JsonResult GetUser(int id)
            => Json(_serviceUsers?.GetUserById(id));
        [HttpPost]
        public JsonResult PostUser(User user)
            => Json(_serviceUsers?.Create(user));
        [HttpPut]
        public JsonResult PutUser(User user)
            => Json(_serviceUsers?.Update(user));
        [HttpDelete("{id}")]
        public bool DeleteUser(int id) 
            => _serviceUsers.Delete(id);
    }
}
