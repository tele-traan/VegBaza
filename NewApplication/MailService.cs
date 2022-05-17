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
        public static void SendEmail(Order order)
        {
            try
            {
                MailMessage message = new();
                message.IsBodyHtml = true;
                message.From = new MailAddress("vegbaza@mail.ru", "Овощебаза");
                message.To.Add(order.Email);
                message.Subject = "Корзины, которые вы заказали в нашем магазине:";

                var plainView = AlternateView.CreateAlternateViewFromString("VegBaza", null, "text/plain");
                List<string> vegNames = new();
                List<LinkedResource> vegImages = new();
                var htmlView = AlternateView.CreateAlternateViewFromString("");

                int index = 0;
                string htmlViewLine = "";

                foreach (var el in order.OrderDetails)
                {
                    vegImages.Add(new LinkedResource("wwwroot" + el.Veg.Img));
                    vegImages[index].ContentId = "ID" + el.Id;
                    htmlViewLine += "<p>" + el.Veg.LongDesc + "</p>" + "<img style='width: 500px' src =cid:" + vegImages[index].ContentId + ">";
                    index++;
                }

                htmlView = AlternateView.CreateAlternateViewFromString(htmlViewLine, null, "text/html");

                index = 0;
                foreach (var el in order.OrderDetails)
                {
                    htmlView.LinkedResources.Add(vegImages[index]);
                    index++;
                }


                message.AlternateViews.Add(plainView);
                message.AlternateViews.Add(htmlView);


                using SmtpClient client = new("smtp.gmail.com");
                client.Credentials = new NetworkCredential("ПОЧТА", "ПАРОЛЬ");
                client.Port = 587;
                client.EnableSsl = true;

                client.Send(message);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}