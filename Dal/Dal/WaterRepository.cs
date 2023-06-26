using Dal.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WaterPOC.Repository;
using WaterPOC.Repository.Models;
using System.Linq;


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

        public List<WaterLog> GetWaterLog(int? id, string featureName, string locationDescription)
        {
            List<WaterLog> result = new List<WaterLog>();
            var results = _db.WaterLog.AsQueryable();

            Debug.WriteLine("id is:" + id);
            Debug.WriteLine("feature is:"+featureName);
            Debug.WriteLine("loca is:" + locationDescription);


            if (id != null) {
                //p = _db.WaterLog.FirstOrDefault(x => x.Id == id);
                results = results.Where(b => b.Id.ToString().StartsWith(id.ToString()))
        ;
            }
            if (!string.IsNullOrEmpty(featureName))
                results = results.Where(x => x.FeatureName.Contains(featureName));
            if (!string.IsNullOrEmpty(locationDescription))
                results = results.Where(x => x.LocationDescription.Contains(locationDescription));



            return results.ToList();
        }


    }
}