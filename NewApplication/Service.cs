using Microsoft.Extensions.Logging;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Shop.MailServices
{
    public class MailService
    {
        private readonly ILogger<MailService> logger;
        public MailService(ILogger<MailService> logger)
        {
            this.logger = logger;
        }
        public void SendEmail(Order order)
        {
            try
            {
                MailMessage message = new();
                message.IsBodyHtml = true;
                message.From = new MailAddress("vegbaza@mail.ru", "Овощебаза");
                message.To.Add(order.email);
                message.Subject = "Корзины, которые вы заказали в нашем магазине:";

                var plainView = AlternateView.CreateAlternateViewFromString("VegBaza", null, "text/plain");
                List<string> veg_names = new();
                List<LinkedResource> veg_images = new();
                var htmlView = AlternateView.CreateAlternateViewFromString("");

                int index = 0;
                string htmlView_Line = "";

                foreach (var el in order.orderDetails)
                {
                    veg_images.Add(new LinkedResource("wwwroot" + el.veg.img));
                    veg_images[index].ContentId = "ID" + el.id;
                    htmlView_Line += "<p>" + el.veg.longDesc + "</p>" + "<img style='width: 500px' src =cid:" + veg_images[index].ContentId + ">";
                    index++;
                }

                htmlView = AlternateView.CreateAlternateViewFromString(htmlView_Line, null, "text/html");

                index = 0;
                foreach (var el in order.orderDetails)
                {
                    htmlView.LinkedResources.Add(veg_images[index]);
                    index++;
                }


                message.AlternateViews.Add(plainView);
                message.AlternateViews.Add(htmlView);


                using SmtpClient client = new("smtp.gmail.com");
                client.Credentials = new NetworkCredential("INSERT GMAIL", "INSERT-PASSWORD"); //put your mail credentials here
                client.Port = 587;
                client.EnableSsl = true;

                client.Send(message);
                logger.LogInformation("Сообщение отправлено успешно!");
            }
            catch (Exception e)
            {
            }
        }
    }
}