using System;
using System.Net.Mail;

namespace TestSendSMTPMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMsg();
            Console.ReadKey();

        }

        private static void SendMsg()
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress("ehalsey@a-cto.com", "Eric"));
            msg.From = new MailAddress("ehalseyhb@actodev2.onmicrosoft.com", "Eric");
            msg.Subject = "This is a Test Mail";
            msg.Body = "This is a test message using Exchange OnLine";
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("ehalseyhb@actodev2.onmicrosoft.com", "");
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
                Console.WriteLine("Message Sent Succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
