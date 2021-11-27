using DockerLogging.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerLogging.API.Interfaces
{
    public interface IQuickOrderLogic
    {
        Guid PlaceQuickOrder(QuickOrder quickOrder, int customerid);
    }
}
