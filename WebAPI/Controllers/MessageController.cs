using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIs_.Models;

namespace WebAPIs_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly IMapper _IMapper;

        private readonly IMessage _IMessage;
        public MessageController(IMapper mapper, IMessage message)
        {
            _IMapper = mapper;
            _IMessage = message;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/add")]
        public async Task<List<Notifies>> Add(MessageViewModel message)
        {
            message.UserId = await RetornaIdUsuarioLogado();

            var messageMap = _IMapper.Map<Message>(message);

            await _IMessage.Add(messageMap);

            return messageMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/delete")]
        public async Task<List<Notifies>> Delete(MessageViewModel message)
        {
            message.UserId = await RetornaIdUsuarioLogado();

            var messageMap = _IMapper.Map<MessageViewModel, Message>(message);

            await _IMessage.Delete(messageMap);

            return messageMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/GetEntityById")]
        public async Task<MessageViewModel> GetEntityById(Message message)
        {
            message = await _IMessage.GetEntityById(message.Id);

            var messageMap = _IMapper.Map<Message, MessageViewModel>(message);

            return messageMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/list")]
        public async Task<List<MessageViewModel>> List()
        {
            var listMessages = await _IMessage.List();

            var listMessagesMap = _IMapper.Map<List<Message>, List<MessageViewModel>>(listMessages);

            return listMessagesMap;
        }

        private async Task<string> RetornaIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("id");
                return idUsuario.Value;
            }

            return string.Empty;
        }

    }
}
