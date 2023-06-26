using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPOC.Repository.Models;

namespace Bll
{

    public class BllFacade: IBllFacade
    {
        private readonly IWaterBll _waterBll;


        //can pass multiple interfaces here, this is where all functionality ends up
        public BllFacade(IWaterBll bll)
        {
            _waterBll = bll;

        }

        public List<WaterLog> GetAllWaterLogs()
        {
            return _waterBll.GetAllWaterLogs();
        }

        public List<WaterLog> GetWaterLog(int? id, string featureName, string locationDescription)
        {
            return _waterBll.GetWaterLog(id, featureName, locationDescription);
        }


    }
}
