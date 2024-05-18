using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTechSedesPacientesApp.Data.Repository
{
    public interface IRespository<T> where T : class
    {
        T GetById(Guid Id);
        T GetByIdM(int Id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Create(IEnumerable<T> entity);
        void Update(T entity);
        void Delete(Guid Id);
    }
}
