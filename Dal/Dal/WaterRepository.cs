using Dal.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WaterPOC.Repository;
using WaterPOC.Repository.Models;


namespace Dal
{
    public class WaterRepository : IWaterRepository
    {

        //di for db
        private readonly WaterDbContext _db;

        public WaterRepository(IUnitOfWork uwo) { 
            //using UOW to inject DbContext, is this the way?
            _db = uwo.Context;

        }
        public List<WaterLog> GetAllWaterLogs()
        {
            return _db.WaterLog.ToList();
        }

        public WaterLog GetWaterLog(int id, string featureName, string locationDescription)
        {
            WaterLog p = new WaterLog();

            Debug.WriteLine("id is:" + id);
            Debug.WriteLine("feature is:"+featureName);
            Debug.WriteLine("loca is:" + locationDescription);


            if (id != null) {
                p = _db.WaterLog.FirstOrDefault(x => x.Id == id);
            }
            


            return p;
        }


    }
}