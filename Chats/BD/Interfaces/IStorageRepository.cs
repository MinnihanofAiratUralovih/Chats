using BD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Interfaces
{
    public interface IStorageRepository : IBaseRepository<Storage>
    {
        List<Storage> Return10Messages(int idchat,int extreme);//вернуть 10 последних сообщений         extreme (изначально всегда = 0) = для возвращения сообщений старых (номер id остановки)

        bool EditMessage(int id,string txt);//изменить сообщение

        string Size(string idchat);//размер хранилища одного чата

        string Select2(string idchat);//размер 10 ID сообщений последних
    }
}
