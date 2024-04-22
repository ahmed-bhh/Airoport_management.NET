using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        /* //DbContext ctx;
         IUnitOfWork unitOfWork;
        // IGenericRepository<Plane> repo;

         public ServicePlane(DbContext ctx,IGenericRepository<Plane> repo)
         {
            // this.ctx = ctx;//min 16:28
            // this.repo = repo;
         }

         public void Add(Plane f)
         {
           //  repo.Add(f);
                 }

         public void Delete(Plane f)
         {
            // ctx.Set<Plane>().Remove(f);
         }

         public IEnumerable<Plane> GetAll()
         {
             return ctx.Set<Plane>();
         }*/
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
