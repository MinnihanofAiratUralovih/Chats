using Chats.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Chats.Client.Pages.User.Chatss;

namespace Chats.Client
{
    public static class StaticClass
    {
        private static int pagePhases = 0;//фазы страниц
        public static int PagePhases
        {
            get => pagePhases;
            set
            {
                pagePhases = value;
                Update();
            }
        }

        public static event Action? OnChange;

        public static void Update()
        {
            OnChange?.Invoke();
        }

        //1111111111111111111111111111111111111111111111111111111111111111
        public static IList<Friend> friend = new List<Friend>();
        public static IList<Chats2> chats = new List<Chats2>();
        public static IList<txt2> txt = new List<txt2>();
        public static IList<user2> user0 = new List<user2>();
        public static IList<string> masIDUsers = new List<string>();

        public static string ID { get; set; }//ID пользователя
        public static string Name { get; set; }
        public static string Status { get; set; }//кем является (1,2,3 учитель, ученик, родитель. 4 администратор)
        public static string InhichChats { get; set; }//в каких чатах находиться
        public static string Friends { get; set; }//Друзья
    }
}
