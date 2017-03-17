using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Models;
using ChatData;

namespace Chat.Controllers
{
    public class ChatController : ApiController
    {

        [HttpGet]
        [Route("api/Chat")]
        public List<string> GetMessages()
        {
            return ChatData.ChatServerHandler.returnMessages();
        }

        [HttpGet]
        [Route("api/Chat/{id}")]
        public List<string> GetMessages(long id)
        {
            return ChatData.ChatServerHandler.returnMessages(id);
        }

        [HttpGet]
        [Route("api/Post/{user}/{pass}/{message}")]
        public long PostMessage(string user, string pass, string message)
        {
            return ChatData.ChatServerHandler.postMessage(user, pass, message);
        }

    }
}
