using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatory.Interfaces
{
    public interface IGenaricReopsatory<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();

        void Update(T entity);
        void Delete(T entity);

        void Add(T entity);

    }
}
    