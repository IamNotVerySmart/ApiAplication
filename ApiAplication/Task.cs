namespace ApiAplication
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual User User { get; set; }
        public virtual TaskCategory Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual TaskPriority Priority { get; set; }
        public virtual TaskStatus Status { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
