using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPOC.Repository.Models;

namespace Bll
{
    public interface IBllFacade
    {
        List<WaterLog>? GetAllWaterLogs();

        List<WaterLog>? GetWaterLog(int? id, string featureName, string locationDescription);
    }
}
