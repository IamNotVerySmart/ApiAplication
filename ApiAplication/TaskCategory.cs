namespace ApiAplication
{
    public class TaskCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
