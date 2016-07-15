using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebServise_Pizza.Models
{
    public class OrderingApp : DropCreateDatabaseAlways<OrderContext>
    {
        protected override void Seed(OrderContext db)
        {
            db.Orders.Add(new Order { Name = "Товар1", Adress = "Адрес 1"});
            db.Orders.Add(new Order { Name = "Товар2", Adress = "Адрес 2"});
            db.Orders.Add(new Order { Name = "Товар3", Adress = "Адрес 3"});

            base.Seed(db);
        }
    }
}