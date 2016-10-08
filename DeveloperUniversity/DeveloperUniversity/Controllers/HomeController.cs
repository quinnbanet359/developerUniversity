using System.Net.Mail;
using System.Web.Mvc;
using DeveloperUniversity.Models.ViewModels;
using reCAPTCHA.MVC;

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

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidator(
        PrivateKey = "6LehwAgUAAAAACXHKuFtJmdZWWPvf7--XsaZiRsw",
        ErrorMessage = "Invalid input captcha.",
        RequiredMessage = "The captcha field is required.")]
        public ActionResult Contact(MailViewModel viewModel)
        {
            //For help on setting up the captcha visit the link below and refer to the "Quick Start" guide.
            //http://recaptchamvc.apphb.com/


            //To get your site and private keys for the captcha, visit the link below.
            // https://www.google.com/recaptcha/intro/index.html


            //Below is how to set up a contact form for GMAIL ONLY!.

            //If you receive an error on Line smtp.Send(mail) then you might need to log into that Gmail 
            //account you are trying to send the emails from and find the option to "Enable Less Secure Apps"
            //Google is being nice and disabling the Gmail account to be accessed by less secure applications.

            //See the referenced code for explanation of this example.
            //http://www.c-sharpcorner.com/uploadfile/sourabh_mishra1/sending-an-e-mail-using-asp-net-mvc/
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("gmailAddress");
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
                ("gmailAddress", "gmailPassword");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index");
            }
            else
            {
                return View();
            }

        }
    }
}