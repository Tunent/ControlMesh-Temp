using ControlMesh.Database.Models;
using ControlMesh.Services.ViewModels;

namespace ControlMesh.Services
{
    public interface IMessageServiceMapper
    {
        MessageViewModel GetMessageMapper(Message message);
    }
}
