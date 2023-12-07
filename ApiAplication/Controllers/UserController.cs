using Microsoft.AspNetCore.Mvc;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost("name")]
        public User Add(string name)
        {
            User user = new User { Name = name };
            _context.Users.Add(user);
            _context.SaveChanges();
            foreach (var item in _context.Users)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
            return user;
        }
        [HttpPut("{id},{name}")]
        public User Update(int id, string name)
        {
            _context.Users.FirstOrDefault(x => x.Id == id).Name = name;
            User edit = _context.Users.FirstOrDefault(x => x.Id == id);
            return edit;
        }
        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }
    }
}
