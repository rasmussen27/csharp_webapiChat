using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    /// <summary>
    /// not used, was used for some testing
    /// </summary>
    public class ChatMessage
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Message { get; set; }
    }
}