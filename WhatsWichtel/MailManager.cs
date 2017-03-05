using System;

using System.Diagnostics;
using System.Net.Mail;

namespace WhatsWichtel
{
    class MailManager
    {
        /// <summary>
        /// .Net Objekt zum versenden von Mails
        /// </summary>
        private SmtpClient smtpClient;
        /// <summary>
        /// Aktive Form
        /// </summary>
        private WichtelForm WichtelWindow;
        /// <summary>
        /// Host des Emailanbieters (z.B. smtp.web.de)
        /// </summary>
        private string host;
        /// <summary>
        /// Emailadresse
        /// </summary>
        private string emailAdress;
        /// <summary>
        /// Passwort zum Emailaccount
        /// </summary>
        private string password;

        /// <summary>
        /// Getter/Setter
        /// </summary>
        public string Host { get { return this.host; } set { this.host = value; } }
        public string EmailAdress { get { return this.emailAdress; } set { this.emailAdress = value; } }
        public string Password { set { this.password = value; } }


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="host"></param>
        /// <param name="emailAdress"></param>
        /// <param name="password"></param>
        public MailManager(string host,string emailAdress,string password,WichtelForm window)
        {
            this.host = host;
            this.emailAdress = emailAdress;
            this.password = password;
            this.smtpClient = new SmtpClient(host);
            smtpClient.Credentials = new System.Net.NetworkCredential(emailAdress, password);
            //Eventhandler verbinden
            //smtpClient.SendCompleted += new
            //SendCompletedEventHandler(SendCompletedCallback);

            this.WichtelWindow = window;
        }

        //static int mailSendCounter;
        //private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        //{
        //    // Get the unique identifier for this asynchronous operation.
        //    String token = (string)e.UserState;

        //    if (e.Cancelled)
        //    {
        //        Debug.Print("[{0}] Send canceled.", token);
        //    }
        //    if (e.Error != null)
        //    {
        //       Debug.Print("[{0}] {1}", token, e.Error.ToString());
        //    }
        //    else
        //    {
        //        Debug.Print("Message sent.");
        //        mailSendCounter++;
        //        Debug.Print("Mails send: "+mailSendCounter);
        //    }
        //}
        /// <summary>
        /// Versendet Email via SMTP
        /// </summary>
        /// <param name="ziel"></param>
        /// <param name="Nachricht"></param>
        /// <param name="betreff"></param>
        /// <returns></returns>
        public bool SendEmail(string ziel,string Nachricht,string betreff)
        {
            MailAddress from = new MailAddress("misterwichtel@web.de","MisterWichtel",System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(ziel);
            MailMessage message = new MailMessage(from,to);
            message.Body = Nachricht;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = betreff;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex) 
            { 
                Debug.Print(ex.Message);
                return false;
            }
        }
 


    }
}
