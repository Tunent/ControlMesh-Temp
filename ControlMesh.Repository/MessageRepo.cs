using ControlMesh.Database;
using ControlMesh.Database.Models;
using ControlMesh.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlMesh.Repository
{
    public class MessageRepo : IMessageRepo
    {
        private readonly ControlMeshDataContext _context;

        public MessageRepo(ControlMeshDataContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Message message)
        {
            var newMessage = new Message
            {
                Content = message.Content,
                Created = DateTime.UtcNow,
                MessageSystemProperties = message.MessageSystemProperties,
                MessageCustomProperties = message.MessageCustomProperties
            };

            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Message>> GetPaginatedMessassagesAsync(int? page, int pageSize)
        {
            var countDetails = _context.Messages.Count();
            var result = new PaginatedResult<Message>
            {
                Count = countDetails,
                PageIndex = page ?? 1,
                PageSize = pageSize,
                Items = await _context.Messages.Skip((page - 1 ?? 0) * pageSize).Take(pageSize).ToListAsync()
            };
            return result;
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            //Needs further mapping?
            var message = await _context.Messages
                .Include(x => x.MessageCustomProperties)
                .Include(x => x.MessageSystemProperties)
                .SingleOrDefaultAsync(x => x.Id == id);

            return message;
        }
    }
}