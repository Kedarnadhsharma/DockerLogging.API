using DockerLogging.API.Interfaces;
using DockerLogging.API.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerLogging.API.Domain
{
    public class ProductLogic : IProductLogic
    {
        private readonly ILogger<ProductLogic> _logger;

        private readonly List<string> _validCategories = new List<string> { "All", "Mobiles", "Electornics", "Home Appliances", "Grocery" };


        public ProductLogic(ILogger<ProductLogic> logger)
        {
            _logger = logger;
        }
        public IEnumerable<Product> GetProductsForCategory(string category)
        {
            _logger.LogInformation("Starting the Log to get the Products for {category}", category);


            if (string.Equals(category, "Books", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception("Not implemented, No books have been defined in database yet!!");
            }

            if (!_validCategories.Any(c => string.Equals(category, c, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ApplicationException($"Unrecongnized Category {category}. " +
                        $"Valid Categories are : [{string.Join(",", _validCategories)}]");
            }

           

            return GetAllProducts().Where(a =>
            string.Equals("All", category, StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(category, a.Category, StringComparison.InvariantCultureIgnoreCase));
                        

           
        }


        private IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product { ID=100, Category="Mobiles", Name="iPhone 13 Pro Max", Description ="Oh so Pro Max", Price = 129000},
                new Product { ID=101, Category="Mobiles", Name="iPhone 13 Pro", Description ="Oh so Pro", Price = 119000},
                new Product { ID=102, Category="Mobiles", Name="iQ007", Description ="Best Value for Money Andriod Phone", Price = 19000},
                new Product { ID=103, Category="Mobiles", Name="Samsung Note 12", Description ="Brilliantly Simpe", Price = 76900},
            };
        }
    }
}
