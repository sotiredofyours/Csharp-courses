using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ControlTasks;

public class SMTP : IUseConsole
{
    private static readonly Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

    private static SmtpClient _client;

    public SMTP() 
    {
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.yandex.ru";
        client.Port = 587;
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential("email", "password");
    }
    
    public void SendMail(string senderEmail, string recipientEmail)
    {
        MailMessage mail = new MailMessage();
        Match match_sen = regex.Match(senderEmail);
        Match match_rec = regex.Match(recipientEmail);
        // Вообще, здесь не нужен Regex, т.к. в new MailAddress ниже уже встроена проверка, и мы получим FormatException, если строка будет невалидна
        // или можно использовать MailAddress.TryCreate
        if (match_sen.Success && match_rec.Success)
        {
            mail.From = new MailAddress(senderEmail); 
            mail.To.Add(new MailAddress(recipientEmail)); 
            mail.Subject = "SMTP";
            mail.Body = "Test message";
           _client.Send(mail);
        }
    }

    public void Run()
    {
        Console.WriteLine("Введите email отправителя");
        var senderEmail = Console.ReadLine()!;
        Console.WriteLine("Введите email получателя");
        var recipientEmail = Console.ReadLine()!;
        SendMail(senderEmail, recipientEmail);
        Console.WriteLine("Сообщение отправлено");
    }
}