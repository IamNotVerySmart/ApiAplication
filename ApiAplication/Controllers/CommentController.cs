using Microsoft.AspNetCore.Mvc;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public List<Comment> Get(int id)
        {
            return _context.Comments.Where(x => x.Id == id).ToList();
        }
        [HttpPost("{nazwa}, {Id task}")]
        public Comment Add(string nazwa, int id)
        {
            Comment comment = new Comment()
            {
                Text = nazwa
            };
            _context.Comments.Add(comment);
            _context.Tasks.FirstOrDefault(x => x.Id == id).Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }
        [HttpDelete("{id}")]
        public Comment Delete(int Id)
        {
            Comment delete = _context.Comments.FirstOrDefault(x => x.Id == Id);
            _context.Comments.Remove(delete);
            return delete;
        }
    }
}
