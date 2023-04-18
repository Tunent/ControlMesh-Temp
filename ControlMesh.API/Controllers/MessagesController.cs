using ControlMesh.Repository;
using ControlMesh.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlMesh.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepo _messageRepo;
        private readonly IMessageServiceMapper _messageServiceMapper;

        public MessagesController(IMessageRepo messageRepo, IMessageServiceMapper messageServiceMapper)
        {
            _messageRepo = messageRepo;
            _messageServiceMapper = messageServiceMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessagesPaginatedAsync(int? page, int pageSize = 10)
        {
            return Ok(await _messageRepo.GetPaginatedMessassagesAsync(page, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageAsync(int id)
        {
            if (id == 0) { return NotFound(); }

            var message = await _messageRepo.GetMessageByIdAsync(id);

            return Ok(_messageServiceMapper.GetMessageMapper(message));
        }
    }
}