using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using BD.Domain.Models;
using BD.Persistance;
using BD.Interfaces;
using Chats.Shared;

namespace Chats.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet("Enter")]//воити в акаунт
        public _String Enter(string login, string password)
        {
            _String _S = new _String() { txt = "false" };
            var response = _usersRepository.Select();
            foreach (var i in response.Result)
                if (i.Lolgin == login && i.Password == password)
                    _S.txt = "" + i.ID;
            return _S;
        }

        [HttpGet("AboutClient")]//все о клиенте
        public _String AboutClient(string ID)
        {
            Users response = _usersRepository.Get(Convert.ToInt32(ID));
            return new _String() { txt = response.ID + " " + response.Name + " " + response.Status + " " + response.InhichChats };
        }

        [HttpGet("Create")]//Создать клиента
        public _String Create(string name, int status, string login, string password)
        {
            Users user = new Users() { Name = name, Status = status, Lolgin = login, Password = password };
            bool i = _usersRepository.Create(user);
            return new _String() { txt = "" };
        }

        [HttpGet("Get")]//Вернуть 1 клиента
        public Users Get(int customersID)
        {
            Users user = _usersRepository.Get(customersID);
            return user;
        }

        [HttpGet("Select")]//выводит имена всех клиентов
        public _String Select()
        {
            var response = _usersRepository.Select();
            string name = "";
            foreach (var i in response.Result)
                name += i.Name + "\n";
            return new _String() { txt = name };
        }

        [HttpGet("Select2")]//выводит имена всех клиентов кроме себя
        public IList<Friend> Select2(int j)
        {
            IList<Friend> friend2 = new List<Friend>();
            var response = _usersRepository.Select();
            int nomer = 1;
            foreach (var i in response.Result)
            {
                if (i.ID != j)
                {
                    Friend friend = new Friend() { Nomer = nomer, IdUser = i.ID, Name = i.Name };
                    friend2.Add(friend);
                    nomer++;
                }
            }
            return friend2;
        }

        [HttpGet("Taketherest")]//вывести всех кого нет в этом чате
        public _String Taketherest(string masUsers2)
        {
            string[] masUsers = masUsers2.Split(' ');
            var response = _usersRepository.Select();
            string txt = "";
            foreach (var i in response.Result)
                txt += i.ID + " ";
            txt = txt.Substring(0, txt.Length - 1);
            string[] txt2 = txt.Split(' ');
            string[] resultArray = txt2.Except(masUsers).ToArray();
            txt = "";
            foreach (var i in resultArray)
                txt += i + " ";
            txt = txt.Substring(0, txt.Length - 1);
            return new _String() { txt = txt };
        }

        [HttpGet("Delete")]//Удалить клиента
        public _String Delete()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("LogChat")]//воити в чат (присоединиться)
        public _String LogChat(int idUser, int idchat)
        {
            _usersRepository.LogChat(idUser, idchat);
            return new _String() { txt = "" };
        }

        [HttpGet("LogOutChat")]//выити из чата
        public _String LogOutChat()
        {
            return new _String() { txt = "" };
        }
    }
}
