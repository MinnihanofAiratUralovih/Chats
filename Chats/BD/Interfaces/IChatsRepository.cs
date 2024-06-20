using BD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Interfaces
{
    public interface IChatsRepository : IBaseRepository<Chats>
    {
        bool ChangeTheName(int idchat, string name);//изменить имя

        bool AddUser(int idchat, int idUser);//добавить пользователя

        bool DeleteUser(int idchat, int idUser);//удалить пользователя

        bool ChangeTheCreator(int idchat, int idUser);//изменить создателя (главного)

        string SelectID();//показать последний созданный элемент ID чата
    }
}
