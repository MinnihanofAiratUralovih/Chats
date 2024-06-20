using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD.Domain.Models
{
    public class Notifications
    {
        [Key]
        public int ID { get; set; }//ID

        [Required]
        public Users IDUsers { get; set; }//ID пользователя который отправил

        [Required]
        public string Type { get; set; }//тип сообщения (приглашение в чат 1, приглашение в друзья 2, сообщения 3)

        [Required]
        public string Text { get; set; }//(ID чата, ID человека, сообщение) (в тексте ID чата)
    }
}
