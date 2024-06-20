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
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository _contacts;

        public ContactsController(IContactsRepository contacts)
        {
            _contacts = contacts;
        }

        [HttpGet("ShowFriends")]//показать друзей
        public _String ShowFriends(int ID)
        {
            Contacts contacts = _contacts.Get(ID);
            try
            {
                return new _String() { txt = contacts.Friends};
            }
            catch (Exception e)
            {
                return new _String() { txt = "друзей нет" };
            }
        }

        [HttpGet("Create")]//Создать контакт
        public _String Create()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("Get")]//Вернуть 1 контакт
        public Contacts Get(int customersID)
        {
            Contacts contacts = _contacts.Get(customersID);
            return contacts;
        }

        [HttpGet("Select")]//выводит имена всех контакт
        public _String Select()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("Delete")]//Удалить контакт
        public _String Delete()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("AddFriends")]//Удалить уведомления
        public _String AddFriends()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("DeleteFriends")]//Удалить уведомления
        public _String DeleteFriends()
        {
            return new _String() { txt = "" };
        }
    }
}
