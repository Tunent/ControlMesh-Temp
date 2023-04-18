namespace ControlMesh.Services.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime Created { get; set; }
        public MessageCustomPropertiesViewModel MessageCustomProperties { get; set; }
        public MessageSystemPropertiesViewModel MessageSystemProperties { get; set; }
    }
}
