using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public interface IRepository<T> where T:Entity
    {
        T Add(T entity);
        T Delete(int id);
        T Get(int id);
        T Update(T entity);
        IQueryable<T> Items { get; }
    }
}
