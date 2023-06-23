using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPOC.Repository;

namespace Dal.Repository
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        public UnitOfWork(WaterDbContext context)
        {
            Context = context;
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public WaterDbContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
