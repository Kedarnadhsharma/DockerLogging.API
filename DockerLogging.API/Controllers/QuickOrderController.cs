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
    public class QuickOrderController : Controller
    {
        private readonly ILogger _logger;
        private readonly IQuickOrderLogic _quickOrderLogic;
        public QuickOrderController(ILogger<QuickOrderController> logger, IQuickOrderLogic quickOrderLogic)
        {
            _logger = logger;
            _quickOrderLogic = quickOrderLogic;
        }

        [HttpPost]
        public Guid SubmitQuickOrder(QuickOrder info)
        {
            _logger.LogInformation("Submitting order for {orderinfo.quantity}", info.Quantity);
            return _quickOrderLogic.PlaceQuickOrder(info, 1234);
        }
    }
}
