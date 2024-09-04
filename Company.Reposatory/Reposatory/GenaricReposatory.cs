using Company.Data.Contexts;
using Company.Data.Models;
using Company.Reposatory.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Company.Reposatory.Reposatory
{
    public class GenaricReposatory<T> : IGenaricReopsatory<T> where T : BaseEntity
    {
        private readonly CompanyDBContext _context;
        public GenaricReposatory(CompanyDBContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
     
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
       
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);

        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);

        }
    }
}