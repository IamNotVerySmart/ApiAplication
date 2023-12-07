using Microsoft.AspNetCore.Mvc;

namespace ApiAplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TaskCategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<TaskCategory> Gets()
        {
            return _context.TaskCategories.ToList();
        }
        [HttpGet("{id}")]
        public TaskCategory Get(int id)
        {
            return _context.TaskCategories.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost("{task}")]
        public TaskCategory Add(string name)
        {
            var taskCategory = new TaskCategory()
            {
                Name = name
            };
            _context.TaskCategories.Add(taskCategory);
            _context.SaveChanges();
            return taskCategory;
        }
        [HttpPut("{id}/{task}")]
        public TaskCategory Update(int id, string name)
        {
            _context.TaskCategories.FirstOrDefault(x => x.Id == id).Name = name;
            TaskCategory edit = _context.TaskCategories.FirstOrDefault(x => x.Id == id);
            return edit;
        }
        [HttpDelete("{id}")]
        public TaskCategory Delete(int id)
        {
            var taskCategory = _context.TaskCategories.FirstOrDefault(x => x.Id == id);
            _context.TaskCategories.Remove(taskCategory);
            _context.SaveChanges();
            return taskCategory;
        }
    }
}