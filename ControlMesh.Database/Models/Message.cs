namespace ControlMesh.Database.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime Created { get; set; }
        public virtual MessageSystemProperties? MessageSystemProperties { get; set; }
        public virtual MessageCustomProperties? MessageCustomProperties { get; set; }
    }
}