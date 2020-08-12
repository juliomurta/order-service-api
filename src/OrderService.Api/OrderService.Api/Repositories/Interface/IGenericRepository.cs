using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories.Interface
{
    public interface IGenericRepository<T> where T: class, new() 
    {
        T Create(T model);

        T Update(T model);

        bool Delete(Func<T, bool> func);

        T Get(Func<T, bool> func);
    }
}
