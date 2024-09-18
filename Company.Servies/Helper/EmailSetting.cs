using System.Net;
using System.Net.Mail;
namespace Company.Servies.Helper
{
    public class EmailSetting
    {

        public static void SendEmail(Email input)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("rawany213@gmail.com", "lwdsrpywpmobvthd");
            client.Send("rawany213@gmail.com", input.To, input.Subject, input.Body);
        }
    }
}
