using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class ContactController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("carshopasp@gmail.com", "aspcarshop");

                    using (var message = new MailMessage(model.FromEmail, "carshopasp@gmail.com"))
                    {
                        message.Subject = "Message from " + model.FromName + "; E-mail: " + model.FromEmail;
                        message.Body = model.Message;
                        message.IsBodyHtml = true;
                        smtp.Send(message);
                    }

                    ViewBag.message = "Thank you for your feedback, " + model.FromName + "! Your message was sent successfully.";
                    return View("Index");
                }
                catch (Exception)
                {
                    ViewBag.message = "We are sorry, " + model.FromName + ". Something went wrong.";
                    return View("Index");
                }
            }
            return View("Index");
        }
    }
}