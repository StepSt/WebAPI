﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServise_Pizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        //public DateTime Time { get; set; }
    }
}