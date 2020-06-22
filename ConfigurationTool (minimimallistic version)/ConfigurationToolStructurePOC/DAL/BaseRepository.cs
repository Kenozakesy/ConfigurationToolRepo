using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        public BaseRepository(IConfigurationToolContext context)
        {
            Context = context;
        }

        protected virtual IQueryable<T> Include(IQueryable<T> entities)
        {
            return entities;
        }

        protected IConfigurationToolContext Context { get; private set; }

        public abstract IEnumerable<T> GetAll();

        public abstract void Add(T entity);


        public virtual void Delete(T entity)
        {
            Context.SetDeleted(entity);
        }

        public virtual void Update(T entity)
        {
            Context.SetModified(entity);
        }
    }
}
