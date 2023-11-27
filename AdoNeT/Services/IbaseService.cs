using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNeT.Services
{
    public interface IBaseService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Create(T data);
        int Update(int id, T data);
        int Delete(int id);
    }
}
