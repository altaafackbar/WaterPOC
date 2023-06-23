using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPOC.Repository.Models;

namespace Dal
{
    public interface IWaterRepository
    {
        public List<WaterLog> GetAllWaterLogs();

        public WaterLog GetWaterLog(int id, string featureName, string locationDescription);

    }
}
