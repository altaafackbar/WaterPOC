using WaterPOC.Repository.Models;
using System.Collections.Generic;
using Dal;
using System;
using WaterPOC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bll
{
    public class WaterBll: IWaterBll
    {

        //add by di like controller --DONE

        //create interface for dal
        //always do an interface for services

        //entities -> model in DAL

        //repo mapping to table or view
        //"combines" info from sources 

        //persondal->personrepo

        private IWaterRepository _dal;

        public WaterBll(IWaterRepository repo)
        {
            _dal = repo;
        }

        
        public List<WaterLog> GetAllWaterLogs()
        {
            return _dal.GetAllWaterLogs();
        }

        public List<WaterLog> GetWaterLog(int? id, string featureName, string locationDescription)
        {
            List<WaterLog> result = _dal.GetWaterLog(id, featureName, locationDescription);


            return result;
        }




    }
}