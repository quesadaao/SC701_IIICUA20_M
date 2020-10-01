using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Solution.DAL.Repository
{  
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SolutionDBContext dBContext;
        public Repository(SolutionDBContext context) 
        {
            dBContext = context;        
        }

        public IQueryable<T> AsQueryble()
        {
            return dBContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            dBContext.SaveChanges();
            //dBContext.Database.CloseConnection();
        }

        public void Delete(T entity)
        {
            try
            {
                dBContext.Entry<T>(entity).State = EntityState.Deleted;
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
