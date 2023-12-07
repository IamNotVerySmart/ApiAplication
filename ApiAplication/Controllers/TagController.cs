using Microsoft.AspNetCore.Mvc;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public List<Tag> Get(int id)
        {
            return _context.Tags.Where(x => x.Id == id).ToList();
        }
        [HttpPost("{nazwa}, {Id task}")]
        public Tag Add(string nazwa, int id)
        {
            Tag tag = new Tag()
            {
                Name = nazwa
            };
            _context.Tags.Add(tag);
            _context.Tasks.FirstOrDefault(x => x.Id == id).Tags.Add(tag);
            _context.SaveChanges();
            return tag;
        }
        [HttpDelete("{id}")]
        public Tag Delete(int Id)
        {
            Tag delete = _context.Tags.FirstOrDefault(x => x.Id == Id);
            _context.Tags.Remove(delete);
            return delete;
        }
    }
}
