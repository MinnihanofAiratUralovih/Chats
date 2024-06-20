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
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsRepository _notifications;
        private readonly IUsersRepository _usersRepository;
        private readonly IChatsRepository _chats;

        public NotificationsController(INotificationsRepository notifications, IUsersRepository usersRepository, IChatsRepository chats)
        {
            _notifications = notifications;
            _usersRepository = usersRepository;
            _chats = chats;
        }

        [HttpGet("Create")]//Создать уведомления
        public _String Create(int IDUser, int IDChats)
        {
            Users user = _usersRepository.Get(IDUser);
            Notifications notifications = new Notifications() { IDUsers = user, Type = user.ID.ToString(), Text = "" + IDChats };
            _notifications.Create(notifications);
            return new _String() { txt = "" };
        }

        [HttpGet("Get")]//Вернуть 1 уведомления
        public Notifications Get(int customersID)
        {
            Notifications notifications = _notifications.Get(customersID);
            return notifications;
        }

        [HttpGet("GetMy")]//Вернуть свои уведомления
        public IList<Notifications11> GetMy(string IDChats, string IDUser)
        {
            IList<Notifications11> notifications = new List<Notifications11>();
            if (IDChats == null)
                return notifications;
            var response = _notifications.Select();
            string[] user2 = IDChats.Split(',');
            if (user2.Length == 0)
                user2[0] = IDChats;
            int ii = 1;

            BD.Domain.Models.Chats chats = null;
            foreach (var i in user2)
            {
                foreach (var j in response.Result)
                {
                    if (i == j.Text)
                    {
                        chats = _chats.Get(Convert.ToInt32(j.Text));
                        Notifications11 notifications1 = new Notifications11() { IDТNotification=j.ID, ID = ii, IDChats = chats.ID, IDUser = j.Type, IDName = _usersRepository.Get(Convert.ToInt32(j.Type)).Name, NameChats =chats.Name};
                        notifications.Add(notifications1);
                        ii++;
                    }
                }
            }
            return notifications;
        }

        [HttpGet("Select")]//выводит имена всех уведомления
        public _String Select()
        {
            return new _String() { txt = "" };
        }

        [HttpGet("Delete")]//Удалить уведомления
        public _String Delete(int IDnotification)
        {
            _notifications.Delete(_notifications.Get(IDnotification));
            return new _String() { txt = "" };
        }

        [HttpGet("ToAccept")]//Удалить уведомления
        public _String ToAccept()
        {
            return new _String() { txt = "" };
        }

        public class Notifications11
        {
            public int ID { get; set; }//ID
            public int IDТNotification { get; set; }//IDNotification 
            public int IDChats { get; set; }//ID чата
            public string NameChats { get; set; }//имя чата
            //public string Сreator { get; set; }//Создатель чата
            public string IDName { get; set; }//имя подавателя
            public string IDUser { get; set; }//ID подавателя
        }
    }
}
