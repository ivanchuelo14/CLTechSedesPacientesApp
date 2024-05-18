using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTechSedesPacientesApp.Data.Repository
{
    public class Repository<T> : IRespository<T> where T : class
    {
        private readonly AplicationDbContext _DbContext;

        public Repository(AplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public T GetById(Guid Id)
        {
            try
            {
                return _DbContext.Set<T>().Find(Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public T GetByIdM(int Id)
        {
            return _DbContext.Set<T>().Find(Id);
        }

        public IQueryable<T> GetAll()
        {
            return _DbContext.Set<T>();
        }

        public void Create(T entity)
        {
            _DbContext.Set<T>().Add(entity);
            _DbContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {

            var result = _DbContext.Set<T>().Find(Id);
            if (result != null)
            {
                _DbContext.Set<T>().Remove(result);
                _DbContext.SaveChanges();
            }
        }

        public void Update(T entity)
        {

            _DbContext.Entry(entity).State = EntityState.Modified;
            _DbContext.SaveChanges();
        }
    }
}
