using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPOC.Repository;

namespace Dal.Repository
{
    public interface IUnitOfWork
    {
        int Save();

        WaterDbContext Context { get; }
    }
}
