using Microsoft.AspNetCore.Mvc;
namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Task> Get()
        {
            return _context.Tasks.ToList();
        }
        [HttpGet("{id}")]
        public Task Get(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost("{Title},{Category},{Priority},{Status}")]
        public Task Add(string name, int User, int Category, int Priority, int Status)
        {
            var task = new Task()
            {
                Title = name,
                User = _context.Users.FirstOrDefault(x => x.Id == User),
                Category = _context.TaskCategories.FirstOrDefault(x => x.Id == Category),
                Priority = _context.TaskPriorities.FirstOrDefault(x => x.Id == Priority),
                Status = _context.TaskStatuses.FirstOrDefault(x => x.Id == Status)
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }
        [HttpPut("{id},{Title},{Category},{Priority},{Status}")]
        public Task Update(int id, string name, int User, int Category, int Priority, int Status)
        {
            _context.Tasks.FirstOrDefault(x => x.Id == id).Title = name;
            _context.Tasks.FirstOrDefault(x => x.Id == id).User = _context.Users.FirstOrDefault(x => x.Id == User);
            _context.Tasks.FirstOrDefault(x => x.Id == id).Category = _context.TaskCategories.FirstOrDefault(x => x.Id == Category);
            _context.Tasks.FirstOrDefault(x => x.Id == id).Priority = _context.TaskPriorities.FirstOrDefault(x => x.Id == Priority);
            _context.Tasks.FirstOrDefault(x => x.Id == id).Status = _context.TaskStatuses.FirstOrDefault(x => x.Id == Status);
            Task edit = _context.Tasks.FirstOrDefault(x => x.Id == id);
            return edit;
        }
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return task;
        }
    }
}
