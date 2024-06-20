using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD.Domain.Models
{
    public class Access
    {
        [Key]
        public int IDUser { get; set; }//ID хранилища

        [Required]
        public Chats Acces { get; set; }//доступ
    }
}
