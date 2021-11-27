using DockerLogging.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerLogging.API.Interfaces
{
    public interface IProductLogic
    {
        IEnumerable<Product> GetProductsForCategory(string category);
    }
}
