using Microsoft.EntityFrameworkCore;

namespace ApiAplication
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskCategory> TaskCategories { get; set; }
        public virtual DbSet<TaskPriority> TaskPriorities { get; set; }
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            options.UseMySql(_configuration.GetConnectionString("MySqlConnection"), serverVersion).UseLazyLoadingProxies();
        }
    }
}
