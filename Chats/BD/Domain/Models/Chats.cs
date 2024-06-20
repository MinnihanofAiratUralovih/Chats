using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD.Domain.Models
{
    public class Chats
    {
        [Key]
        public int ID { get; set; }//ID чата

        [Required]
        public string Сreator { get; set; }//Создатель чата

        [Required]
        public string Name { get; set; }//имя чата

        [Required]
        public string IDUsers { get; set; }//пользователи чата

        public ICollection<Storage> Storage { get; set; }
    }
}
