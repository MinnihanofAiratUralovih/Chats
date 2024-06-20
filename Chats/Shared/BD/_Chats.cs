using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.Shared.BD
{
    public class _Chats
    {
        public int ID { get; set; }//ID чата
        public string Сreator { get; set; }//Создатель чата
        public string Name { get; set; }//имя чата
        public string IDUsers { get; set; }//пользователи чата
        //public ICollection<_Storage> Storage { get; set; }
    }
}
