using Microsoft.AspNetCore.Mvc;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TaskStatusController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<TaskStatus> Get()
        {
            return _context.TaskStatuses.ToList();
        }
        [HttpGet("{id}")]
        public TaskStatus Get(int id)
        {
            return _context.TaskStatuses.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost("{name}")]
        public TaskStatus Get(string name)
        {
            TaskStatus taskStatus = new TaskStatus { Name = name };
            _context.TaskStatuses.Add(taskStatus);
            _context.SaveChanges();
            return taskStatus;
        }
        [HttpPut("{id},{name}")]
        public TaskStatus Update(int id, string name)
        {
            _context.TaskStatuses.FirstOrDefault(x => x.Id == id).Name = name;
            TaskStatus edit = _context.TaskStatuses.FirstOrDefault(x => x.Id == id);
            return edit;
        }
    }
}
