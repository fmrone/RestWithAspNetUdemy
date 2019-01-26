using Microsoft.EntityFrameworkCore;
using RestWithAspNetUdemy.Model.Base;
using RestWithAspNetUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        //declaração de um dataset genérico
        private DbSet<T> _dataset;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var entity = _dataset.SingleOrDefault(q => q.Id == id);

            try
            {
                if (entity == null)
                    _dataset.Remove(entity);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(q => q.Id == id);
        }

        public T Update(T item)
        {
            var entity = _dataset.SingleOrDefault(q => q.Id == item.Id);
            if (entity == null)
                return null;

            try
            {
                _context.Entry(entity).CurrentValues.SetValues(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
