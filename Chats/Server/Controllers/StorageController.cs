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

namespace Chats.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IChatsRepository _chats;
        private readonly IUsersRepository _usersRepository;

        public StorageController(IStorageRepository storageRepository, IChatsRepository chats, IUsersRepository usersRepository)
        {
            _storageRepository = storageRepository;
            _chats = chats;
            _usersRepository = usersRepository;
        }

        [HttpGet("Create")]//Создать хранилище
        public _String Create()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("Get")]//Вернуть 1 хранилище
        public Storage Get(int customersID)
        {
            Storage storageuser = _storageRepository.Get(customersID);
            return storageuser;
        }

        [HttpGet("Select")]//выводит имена всех хранилище
        public _String Select()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("Delete")]//Удалить хранилище
        public _String Delete()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("Return10Messages")]//вывести 10 последних сообщений
        public _String Return10Messages(string IDChat)
        {
            //var response = _storageRepository.Select2(IDChat);
            //var size = _storageRepository.Size(IDChat);
            //string name = "";
            //for (int i = 0; i < Convert.ToInt32(size); i++)
            //{
            //    name
            //}
            return new _String() { txt = "false" };
        }

        [HttpGet("Get2")]//Вернуть 10 ID
        public _String Get2(string IDChat)
        {
            return new _String() { txt = _storageRepository.Select2(IDChat) };
        }

        [HttpGet("Get3")]//Вернуть 1 txt
        public _String Get3(string IDChat)
        {
            var storageuser = _storageRepository.Get(Convert.ToInt32(IDChat));
            return new _String() { txt = storageuser.Text };
        }

        [HttpGet("Get4")]//Вернуть 1 IDUser
        public _Int Get4(string IDChat)
        {
            var storageuser = _storageRepository.Get(Convert.ToInt32(IDChat));
            return new _Int() { Int = storageuser.IDUsers.ID };
        }

        [HttpGet("Get5")]//Записать 1 сообщение
        public _Bool Get5(string IDChats, string IDUsers, string Text)//string ID,
        {
            try
            {
                BD.Domain.Models.Chats chats = _chats.Get(Convert.ToInt32(IDChats));
                Users user = _usersRepository.Get(Convert.ToInt32(IDUsers));
                Storage storage = new Storage() { IDChats = chats, IDUsers = user, Text = Text };// ID = Convert.ToInt32(ID)
                _storageRepository.Create(storage);
                return new _Bool() { Bool= true };
            }
            catch (Exception e)
            {
                return new _Bool() { Bool = false };
            }
        }

        [HttpGet("EditMessage")]//выити из чата
        public _String EditMessage()
        {
            return new _String() { txt = "" };
        }
    }
}
