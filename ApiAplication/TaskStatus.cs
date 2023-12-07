namespace ApiAplication
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
