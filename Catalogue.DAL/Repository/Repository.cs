using Catalogue.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalogue.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDataContext context = null;
        private DbSet<T> entities;

        public Repository(IDataContext dataContext)
        {
            context = dataContext;
        }

        private DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                    entities = context.Set<T>();

                return entities;
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }    

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate).AsQueryable();
        }

        public void Dispose()
        {
            context.Dispose();
            entities = null;
        }       
    }
}
