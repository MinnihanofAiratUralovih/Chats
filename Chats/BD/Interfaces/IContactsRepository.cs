using BD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Interfaces
{
    public interface IContactsRepository : IBaseRepository<Contacts>
    {
        bool AddFriends(int idUser, int friend);//добавить друзей

        bool DeleteFriends(int idUser, int friend);//удалить друзей
    }
}
