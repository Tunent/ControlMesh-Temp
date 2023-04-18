using ControlMesh.Database.Models;
using ControlMesh.Repository.Models;

namespace ControlMesh.Repository
{
    public interface IMessageRepo
    {
        Task<Message> GetMessageByIdAsync(int id);
        Task<PaginatedResult<Message>> GetPaginatedMessassagesAsync(int? page, int pageSize);
        public Task InsertAsync(Message message);
    }
}