using MassTransit;
using MassTransit_RabbitMq_Producer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassTransit_RabbitMq_Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IBusControl _bus;

        public ProductController(ILogger<ProductController> logger, IBusControl bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _bus.Publish<Product>(new Product { Id = product.Id, Name = product.Name, Price = product.Price });
            var message = $"Message received. ProductId: { product.Id } in { DateTime.Now }";
            _logger.LogInformation(message);
            return Ok(message);
        }
    }
}
