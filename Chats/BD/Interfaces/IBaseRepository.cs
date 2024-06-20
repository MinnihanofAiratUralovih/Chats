using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);//создать

        T Get(int id);//вернуть один объект

        Task<List<T>> Select();//все вывести    IEnumerable<T>    Task<List<T>>

        bool Delete(T entity);//удалить
    }
}
