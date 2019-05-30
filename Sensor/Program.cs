using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Sensor
{
    public class Program : System.ComponentModel.Component
    {
        static void Main(string[] args)
        {
            try
            {
                string date = DateTime.Now.ToString();
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("huseyinaksel26@gmail.com", "SystemStart");
                mail.To.Add("huseyin.aksel@cq.com.tr");
                mail.Subject = "Sistem Başlatıldı";
                mail.IsBodyHtml = true;
                mail.Body = String.Format("Sistem Başarılı Şekilde Başlatıldı." + " " + "Zaman: {0}", date);
                var sc = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("your@gmail.com", "password") //Gönderen mail adresi şifresi
                };

                sc.Send(mail);
                SystemEvents.SessionEnding += OnSessionEnding;
                SystemEvents.SessionEnded += OnSessionEnded;
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       
        protected virtual void OnStop()
        {
            SystemEvents.SessionEnding -= OnSessionEnding;
            SystemEvents.SessionEnded -= OnSessionEnded;
        }

        protected static void OnSessionEnding(Object sender, SessionEndingEventArgs e)
        {
            if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                string date = DateTime.Now.ToString();
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("huseyinaksel26@gmail.com", "SystemClose");
                mail.To.Add("huseyin.aksel@cq.com.tr");
                mail.Subject = "Sistem Kapatıldı";
                mail.IsBodyHtml = true;
                mail.Body = String.Format("Sistem Kapatıldı." + " " + "Zaman: {0}", date);
                var sc = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("your@gmail.com", "password") //Gönderen mail adresi şifresi
                };

                sc.Send(mail);
            }
        }

        protected static void OnSessionEnded(Object sender, SessionEndedEventArgs e)
        {
            if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                string date = DateTime.Now.ToString();
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("huseyinaksel26@gmail.com", "SystemClose");
                mail.To.Add("huseyin.aksel@cq.com.tr");
                mail.Subject = "Sistem Kapatıldı";
                mail.IsBodyHtml = true;
                mail.Body = String.Format("Sistem Kapatıldı." + " " + "Zaman: {0}", date);
                var sc = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("your@gmail.com", "password") //Gönderen mail adresi şifresi
                };

                sc.Send(mail);
            }
        }
    }

}




