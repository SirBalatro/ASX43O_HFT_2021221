using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Logic
{
    public interface ILogic<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
    }
}
