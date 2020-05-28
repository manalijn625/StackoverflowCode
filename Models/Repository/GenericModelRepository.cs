using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StackOverFlow;

namespace StackOverFlow.Models.Repository
{
    public abstract class GenericModel<T> where T : class
    {
        public StackOverFlowDbContext context;
        public GenericModel(StackOverFlowDbContext _context)
        {
            context = _context;
        }

        public virtual IEnumerable<T> GetAll()
        {
          return   context.Set<T>();
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public virtual T GetById(int ID)
        {
            return context.Set<T>().Find(ID);
          
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
    }
}