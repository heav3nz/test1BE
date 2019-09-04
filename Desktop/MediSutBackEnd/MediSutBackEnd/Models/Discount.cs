using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediSutBackEnd.Models
{
    public class Discount
    {
        public int Id { get; set; }

        public int IdClient { get; set; }

        public int IdProduct { get; set; }

        public decimal DiscountRate { get; set; }

        public DateTime DiscountDate { get; set; }
    }
}