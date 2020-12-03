using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SolutionDBContext dBContext;

        public Repository(SolutionDBContext context)
        {
            dBContext = context;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dBContext.Set<T>().AddRange(entities);
        }

        public IQueryable<T> AsQueryble()
        {
            return dBContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            dBContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            try
            {
                dBContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            catch (Exception ee)
            {
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dBContext.Set<T>();
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return dBContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public T GetOneById(int id)
        {
            return dBContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (dBContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dBContext.Entry<T>(entity).State = EntityState.Added;
            }
            else
            {
                dBContext.Set<T>().Add(entity);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dBContext.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            return dBContext.Set<T>().Where(predicado);
        }

        public void Update(T entity)
        {
            if (dBContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dBContext.Set<T>().Attach(entity);
            }
            dBContext.Entry<T>(entity).State = EntityState.Modified;
        }

    }
}
