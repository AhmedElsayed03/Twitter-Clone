using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.GenericRepo
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetByID(string Id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        string getUserFormToken(string token);
        int SaveChanges();

    }
}
