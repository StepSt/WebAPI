using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServise_Pizza.Models;

namespace WebServise_Pizza.Controllers
{
    public class TelegramController : ApiController
    {
        Telegram.Bot.Api bot = new Telegram.Bot.Api("256546691:AAHrj9UXnVMEWBbPLBxxfGFAKPN5HW5F9ys");
        OrderContext db = new OrderContext();

        // GET api/telegram/Update
        [HttpPost]
        #region
        public void GetUpdate([FromBody]Update update)
        {
            switch (update.message.text)
            {
                case "/start":
                    bot.SendTextMessageAsync(update.message.chat.id, "Cписок комманнд откроется по символу '/', в котором мы можете выбрать интересующий вас товар.");
                    bot.SendTextMessageAsync(update.message.chat.id, "Привет," + update.message.from.first_name);
                    break;
                case "/getname":
                    bot.SendTextMessageAsync(update.message.chat.id, "Список товаров, пришлите номер товара в списке");
                    break;
            }
            int i;
            if (int.TryParse(update.message.text, out i))
            {
                switch (update.message.text)
                {
                    case "1":
                        db.Orders.Add(new Order { Name = "Товар11", Adress = "Адрес 11" });
                        bot.SendTextMessageAsync(update.message.chat.id, "Заказ Товара 1 на Адрес 1 отправлен исполнителю");
                        break;
           //        case "1":
            //        case "2":
            //        case "3":
            //            Book book = db.Books.Find(int.Parse(update.message.text));
            //            bot.SendTextMessageAsync(update.message.chat.id, book.Name);
            //            break;
                    default:
                        Order order = db.Orders.Find(int.Parse(update.message.text));
                        bot.SendTextMessageAsync(update.message.chat.id, order.Name);
                        break;
                }

            }
        }
        #endregion
    }
}