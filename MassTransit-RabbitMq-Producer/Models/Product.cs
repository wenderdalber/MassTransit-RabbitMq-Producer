using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassTransit_RabbitMq_Producer.Models
{
    public class Product
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateUpdatePrice { get; set; }
    }
}
