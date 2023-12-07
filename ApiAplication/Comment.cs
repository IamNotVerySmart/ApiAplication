namespace ApiAplication
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Task Task { get; set; }
    }
}
