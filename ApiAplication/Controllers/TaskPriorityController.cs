using Microsoft.AspNetCore.Mvc;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskPriorityController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TaskPriorityController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<TaskPriority> Get()
        {
            return _context.TaskPriorities.ToList();
        }
        [HttpGet("{id}")]
        public TaskPriority Get(int id)
        {
            return _context.TaskPriorities.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost("{nazwa}")]
        public TaskPriority Add(string name)
        {
            TaskPriority taskPriority = new TaskPriority { Name = name };
            _context.TaskPriorities.Add(taskPriority);
            _context.SaveChanges();
            return taskPriority;
        }
        [HttpPut("{id},{nazwa}")]
        public TaskPriority Update(int id, string name)
        {
            _context.TaskPriorities.FirstOrDefault(x => x.Id == id).Name = name;
            TaskPriority edit = _context.TaskPriorities.FirstOrDefault(x => x.Id == id);
            return edit;
        }
    }
}
