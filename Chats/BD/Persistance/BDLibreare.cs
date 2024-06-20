using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BD.Persistance
{
    public class BDLibreare : DbContext
    {
        public DbSet<Users> users { get; set; } = null!;
        public DbSet<Chats> chats { get; set; } = null!;
        public DbSet<Storage> storage { get; set; } = null!;
        public DbSet<Notifications> notifications { get; set; } = null!;
        public DbSet<Contacts> contacts { get; set; } = null!;

        public BDLibreare(DbContextOptions options) : base(options)
        {
        }
    }
}
