namespace ControlMesh.Database.Models
{
    public class MessageCustomProperties
    {
        public int Id { get; set; }
        public string? MessageType { get; set; }
        public string? EndPoint { get; set; }
        public int MessageForeignKey { get; set; }

        public virtual Message Message { get; set; }
    }
}