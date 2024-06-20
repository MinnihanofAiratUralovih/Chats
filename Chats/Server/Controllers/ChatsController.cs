using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BD.Domain.Models;
using BD.Persistance;
using BD.Interfaces;
using Chats.Shared;
using System.Xml.Linq;

namespace Chats.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatsRepository _chats;
        private readonly IUsersRepository _usersRepository;

        public ChatsController(IChatsRepository chats, IUsersRepository usersRepository)
        {
            _chats = chats;
            _usersRepository = usersRepository;
        }

        [HttpGet("ExistingSelect")]//выводит существующих чатов
        public _String ExistingSelect(string IDChats)
        {
            if (IDChats == null)
                return new _String() { txt = "" };
            var response = _chats.Select();
            string[] user2 = IDChats.Split(',');
            if (user2.Length == 0)
                user2[0] = IDChats;
            string name = "";
            foreach (var j in user2)
                foreach (var i in response.Result)
                {
                    if (i.ID.ToString() == j)
                        name += " " + i.ID + " " + i.Name + "";
                }
            return new _String() { txt = name };
        }

        [HttpGet("Create")]//Создать чат
        public _String Create(string Namechat, string Сreator)
        {
            BD.Domain.Models.Chats chats = new BD.Domain.Models.Chats() { Сreator = Сreator, Name = Namechat, IDUsers = Сreator };
            _chats.Create(chats);
            string selectID = _chats.SelectID();
            bool y = _usersRepository.LogChat(Convert.ToInt32(Сreator), Convert.ToInt32(selectID));
            return new _String() { txt = selectID };
        }

        [HttpGet("Get")]//Вернуть 1 чат
        public BD.Domain.Models.Chats Get(int customersID)
        {
            BD.Domain.Models.Chats chats = _chats.Get(customersID);
            return chats;
        }

        [HttpGet("Chat_Im_Not_In")]//получить чаты в которых меня нет
        public IList<Chats> Chat_Im_Not_In(string IDChats)
        {
            IList<Chats> chats1 = new List<Chats>();
            if (IDChats == null)
                return chats1;
            var response = _chats.Select();
            string[] user2 = IDChats.Split(',');
            if (user2.Length == 0)
                user2[0] = IDChats;
            int ii = 1;

            foreach (var i in user2)
            {
                foreach (var j in response.Result)
                {
                    if (i == j.ID.ToString())
                    {
                        response.Result.Remove(j);
                        break;
                    }
                }

            }
            foreach (var i in response.Result)
            {
                Chats chats2 = new Chats() { ID = ii, IDChats = i.ID, Сreator = i.Сreator, Name = i.Name };
                chats1.Add(chats2);
                ii++;
            }
            return chats1;






            //foreach (var j in user2)
            //    foreach (var i in response.Result)
            //    {
            //        if (i.ID.ToString() != j)
            //        {
            //            name += " " + i.ID + " " + i.Name + "";
            //            Chats chats2 = new Chats() { ID = ii, IDChats=i.ID, Сreator = i.Сreator, Name = i.Name };
            //            chats1.Add(chats2);
            //            ii++;
            //        }
            //    }
            //return chats1;
        }

        [HttpGet("Select")]//выводит имена всех чат
        public _String Select()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("Delete")]//Удалить чат
        public _String Delete(string IDChats, string IDUser)
        {
            BD.Domain.Models.Chats chats = _chats.Get(Convert.ToInt32(IDChats));
            string iDUsers = chats.IDUsers;//пользователи чатом
            string[] user = iDUsers.Split(',');
            if (user.Length == 0)
                user[0] = iDUsers;
            foreach (var i in user)
                _usersRepository.LogOutChat(Convert.ToInt32(i), Convert.ToInt32(IDChats));
            BD.Domain.Models.Chats chats1 = new BD.Domain.Models.Chats() { ID = Convert.ToInt32(IDChats) };
            _chats.Delete(chats1);
            return new _String() { txt = "" };
        }

        [HttpGet("ChatUsers")]//вывести всех пользователей чата
        public _String ChatUsers(string IDChat)
        {
            BD.Domain.Models.Chats chats = _chats.Get(Convert.ToInt32(IDChat));
            string[] user = chats.IDUsers.Split(',');
            string txt = "";
            foreach (var i in user)
                txt += i + " ";
            txt = txt.Substring(0, txt.Length - 1);
            return new _String() { txt = txt };
        }

        [HttpGet("ChangeTheName")]//изменить имя
        public _String ChangeTheName(string NewName, int Chatspozition)
        {
            _chats.ChangeTheName(Chatspozition, NewName);
            return new _String() { txt = "" };
        }

        [HttpGet("AddUser")]//добавить пользователя
        public _String AddUser(int idchat, int idUser)
        {
            _chats.AddUser(idchat, idUser);
            return new _String() { txt = "" };
        }

        [HttpGet("DeleteUser")]//удалить пользователя
        public _String DeleteUser()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("ChangeTheCreator")]//изменить создателя (главного)
        public _String ChangeTheCreator()
        {
            return new _String() { txt = "" };
        }

        public class Chats
        {
            public int ID { get; set; }//ID чата
            public int IDChats { get; set; }//ID чата
            public string Сreator { get; set; }//Создатель чата
            public string Name { get; set; }//имя чата
        }
    }

}
