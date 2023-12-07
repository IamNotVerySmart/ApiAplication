namespace ApiAplication
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
