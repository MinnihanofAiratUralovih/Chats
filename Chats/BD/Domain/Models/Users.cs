using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD.Domain.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }//ID пользователя

        [Required]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }//кем является (1,2,3 учитель, ученик, родитель. 4 администратор)

        public string InhichChats { get; set; }//в каких чатах находиться

        [Required]
        public string Lolgin { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Chats> Chats { get; set; }

        public ICollection<Notifications> Notifications { get; set; }

        public ICollection<Contacts> Contacts { get; set; }
    }
}
