using BD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Interfaces
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        bool LogChat(int idUser, int idchat);//воити в чат (присоединиться)

        bool LogOutChat(int idUser, int idchat);//выити из чата
    }
}
