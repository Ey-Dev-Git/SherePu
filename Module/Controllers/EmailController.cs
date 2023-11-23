
using Castle.Core.Smtp;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MimeKit.Utils;
using Module.Models;

namespace Module.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IConfiguration _config;

        public EmailController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("SendEmail")]
        [IgnoreAntiforgeryToken]
        public IActionResult SendEmail([FromForm] EmailToDo message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailMailKit:EmailUsername").Value)); //อีเมลที่ใช้ส่ง
            email.To.Add(MailboxAddress.Parse(message.To = _config.GetSection("EmailMailKit:EmailUsernameTo").Value));//ส่งไปที่

            if (message.Cc != null)//ส่งสำเนา
            {
                foreach (string ccMessage in message.Cc)
                {
                    if (!string.IsNullOrEmpty(ccMessage))
                    {
                        string[] ccMessages = ccMessage.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string cc in ccMessages)
                        {
                            email.Cc.Add(MailboxAddress.Parse(cc.Trim()));
                        }
                    }
                }
            }

            if (message.Bcc != null)//ส่งสำเนาลับ
            {
                foreach (string bccMessage in message.Bcc)
                {
                    if (!string.IsNullOrEmpty(bccMessage))
                    {
                        string[] bccMessages = bccMessage.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string bcc in bccMessages)
                        {
                            email.Bcc.Add(MailboxAddress.Parse(bcc.Trim()));
                        }
                    }
                }
            }

            //หัวข้อ
            email.Subject = message.Subject;

            //Body
            var bodyBuilder = new BodyBuilder
            {
                TextBody =
                "ชื่อของผู้ติดต่อ  " + message.SenderName + "\n" + "อีเมลของผู้ติดต่อ  " + message.SenderEmail + "\n\n" + "รายละเอียดของข้อความ" + "\n\n" + message.Body
            };

            //ส่งไฟล์
            if (message.File != null)
            {
                var multipart = new Multipart("mixed");
                var attachmentPart = new MimePart("application", "octet-stream")
                {
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = message.File.FileName,
                    Content = new MimeContent(message.File.OpenReadStream())
                };
                multipart.Add(attachmentPart);
                bodyBuilder.Attachments.Add(attachmentPart);
            }
            email.Body = bodyBuilder.ToMessageBody();

            var senderemail = new MimeMessage();
            senderemail.From.Add(MailboxAddress.Parse(_config.GetSection("EmailMailKit:EmailUsername").Value));
            senderemail.To.Add(MailboxAddress.Parse(message.To = message.SenderEmail));
            senderemail.Subject = "ทางอุทยานแห่งชาติแจ้ซ้อนได้รับการแจ้งคำร้องเรียนของท่านเรียบร้อยแล้ว";


            var iconCs = _config.GetSection("EmailMailKit:SendIconCs").Value;
            var bodyBuilderSender = new BodyBuilder
            {
                HtmlBody = $@"
                              <html>
                                <body>
                                    <div>
                                        <p>ถึงคุณ {message.SenderName}</p>
                                        <br>ทางอุทยานได้รับการแจ้ง/คำร้องเรียนของท่านเรียบร้อยแล้ว</br>
                                        <div>โดยจะนำคำร้องเรียนของท่านเข้าสู่กระบวนการพิจารณา</div>
                                        <div>และจะนำไปปรับปรุงแก้ไขต่อไปในภายภาคหน้า</div>
                                        <br>ขอขอบคุณท่านสำหรับการส่งคำร้องเรียน</br>
                                        <br>_____________________________</br>
                                        <div>อุทยานแห่งชาติแจ้ซ้อน</div>
                                        <div>089-851-3355</div>
                                        <p><img src=""{iconCs}"" width=""64"" height=""64""></P>
                                    </div>
                                 </body>
                               </html>"
            };
            senderemail.Body = bodyBuilderSender.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailMailKit:EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailMailKit:EmailUsername").Value, _config.GetSection("EmailMailKit:EmailPassword").Value);
            smtp.Send(email);
            smtp.Send(senderemail);
            smtp.Disconnect(true);

            return Ok("ส่งอีเมลแล้ว");
        }

    }
}
