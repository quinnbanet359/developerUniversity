using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DeveloperUniversity.Models.ViewModels;

namespace DeveloperUniversity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(MailViewModel viewModel)
        {

            //Below is how to set up a contact form for GMAIL ONLY!.

            //If you receive an error on Line smtp.Send(mail) then you might need to log into that Gmail 
            //account you are trying to send the emails from and find the option to "Enable Less Secure Apps"
            //Google is being nice and disabling the Gmail account to be accessed by less secure applications.

            //See the referenced code for explanation of this example.
            //http://www.c-sharpcorner.com/uploadfile/sourabh_mishra1/sending-an-e-mail-using-asp-net-mvc/
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("testpesg@gmail.com");
                mail.From = new MailAddress(viewModel.Email);
                mail.Subject = "Contact Form Submission";
                string Body = viewModel.Messge;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("testpesg@gmail.com", "pesgWelcome1");// Enter senders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index");
            }
            else
            {
                return View();
            }

            //if (ModelState.IsValid)
            //{

            //    StringBuilder message = new StringBuilder();
            //    MailAddress from = new MailAddress(viewModel.Email);
            //    message.Append("Name: " + viewModel.Name + "\n");
            //    message.Append("Email: " + viewModel.Email + "\n");
            //    message.Append(viewModel.Messge);

            //    MailMessage mail = new MailMessage();

            //    SmtpClient smtp = new SmtpClient();

            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;

            //    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("testpesg@gmail.com", "pesgWelcome1");

            //    smtp.Credentials = credentials;
            //    //smtp.UseDefaultCredentials = false;
            //    smtp.EnableSsl = true;


            //    mail.From = from;
            //    mail.To.Add("testpesg@gmail.com");
            //    mail.Subject = "Test enquiry from " + viewModel.Name;
            //    mail.Body = message.ToString();

            //    smtp.Send(mail);
            //}
            //return View();
        }
    }
}