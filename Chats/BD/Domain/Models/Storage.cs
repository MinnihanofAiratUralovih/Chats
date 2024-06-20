using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD.Domain.Models
{
    public class Storage
    {
        [Key]
        public int ID { get; set; }//ID хранилища

        [Required]
        public Chats IDChats { get; set; }//ID чата к которому пренадлежит

        [Required]
        public Users IDUsers { get; set; }//ID написавшего

        [Required]
        public string Text { get; set; }//надпись
    }
}
