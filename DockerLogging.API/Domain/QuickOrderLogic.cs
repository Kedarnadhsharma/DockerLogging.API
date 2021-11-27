using DockerLogging.API.Interfaces;
using DockerLogging.API.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerLogging.API.Domain
{
    public class QuickOrderLogic : IQuickOrderLogic
    {
        private readonly ILogger<QuickOrderLogic> _logger;


        public QuickOrderLogic(ILogger<QuickOrderLogic> logger)
        {
            _logger = logger;
        }
        public Guid PlaceQuickOrder(QuickOrder quickOrder, int customerid)
        {
            _logger.LogInformation("Placing order and sending update for inventory");
            return Guid.NewGuid();
        }
    }
}
