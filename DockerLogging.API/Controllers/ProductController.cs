using DockerLogging.API.Interfaces;
using DockerLogging.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerLogging.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductLogic _productLogic;
        public ProductController(ILogger<ProductController> logger,IProductLogic productLogic)
        {
            _logger = logger;
            _productLogic = productLogic;
        }
        
        [HttpGet]
        public IEnumerable<Product> GetProducts(string category= "all")
        {
            _logger.LogInformation("Starting Controller action GetProducts for the {category}", category);
            return _productLogic.GetProductsForCategory(category);
        }



    }
}
