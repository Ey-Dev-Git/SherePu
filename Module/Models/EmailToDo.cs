
using Microsoft.AspNetCore.Http;

namespace Module.Models
{
    public class EmailToDo
    {
        public string To { get; set; } = string.Empty;
        public string[]? Cc { get; set; }
        public string[]? Bcc { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public IFormFile? File { get; set; }
    }
}
