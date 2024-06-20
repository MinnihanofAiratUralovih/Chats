using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD.Domain.Models
{
    public class Contacts
    {
        [Key]
        public int ID { get; set; }//ID

        [Required]
        public Users IDUsers { get; set; }//ID пользователя

        public string Friends { get; set; }//друзья
    }
}
