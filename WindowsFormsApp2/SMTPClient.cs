using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp2
{
    class SMTPClient
    {
        private string _UserName = "ga33822@onet.pl";
        private string _Password = "Szczecinska143";
        private string _Host = "smtp.poczta.onet.pl";
        private int _Port = 587;
        private string _textBoxToEmail = "ga33822@onet.pl";
        private string _Subject = "PS LAB N2 ZIMA 2018 N14a";

        private SmtpClient _smtpClient = new SmtpClient();
        private NetworkCredential _cred = new NetworkCredential();
        private MailMessage _msgObj = new MailMessage();

        public void Send(string MessageContent)
        {
            
            _cred.Password = _Password;
            _cred.UserName = _UserName;

            _smtpClient.EnableSsl = true;
            _smtpClient.Host = _Host;
            _smtpClient.Port = _Port;            
            _smtpClient.Credentials = _cred;
            _smtpClient.EnableSsl = true;
            
            _msgObj.From = new MailAddress(_UserName);

            var addresses = _textBoxToEmail.Trim().Split(';');
            foreach(var str  in addresses)
            {
                _msgObj.To.Add(new MailAddress(str.Trim()));
            }


            _msgObj.Subject = Subject;
            _msgObj.Body = MessageContent;

            _smtpClient.Send(_msgObj);
        }
        public void AddFiles(List<string> pathsList)
        {
            _msgObj.Attachments.Clear();
            foreach (var filePath in pathsList)
            {
                Attachment file = new Attachment(filePath);
                _msgObj.Attachments.Add(file);
            }
        }



        public string UserName { get => _UserName; set => _UserName = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Host { get => _Host; set => _Host = value; }
        public int Port { get => _Port; set => _Port = value; }
        public string TextBoxToEmail { get => _textBoxToEmail; set => _textBoxToEmail = value; }
        public string Subject { get => _Subject; set => _Subject = value; }
       
    }
}
