using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.Shared.BD
{
    public class _Notifications
    {
        public int ID { get; set; }//ID
       // public _Users IDUsers { get; set; }//ID пользователя которому отправили
        public string Type { get; set; }//тип сообщения (приглашение в чат 1, приглашение в друзья 2, сообщения 3)
        public string Text { get; set; }//(ID чата, ID человека, сообщение)
    }
}
