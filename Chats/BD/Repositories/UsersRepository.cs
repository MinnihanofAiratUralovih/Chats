using BD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Persistance;
using Microsoft.EntityFrameworkCore;
using BD.Domain.Models;

namespace BD.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BDLibreare _bd;

        public UsersRepository(BDLibreare bd)
        {
            _bd = bd;
        }

        public bool Create(Users entity)
        {
            try
            {
                _bd.users.Add(entity);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Users entity)
        {
            try
            {
                var variable = _bd.users.Where(x => x.ID == entity.ID).FirstOrDefault();
                _bd.users.Remove(variable);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Users Get(int id)
        {
            var variable = _bd.users.Where(x => x.ID == id)
               .FirstOrDefault();
            return variable;
        }

        public bool LogChat(int idUser, int idchat)
        {
            try
            {
                var variable = _bd.users.Where(x => x.ID == idUser).FirstOrDefault();
                if (variable.InhichChats == null || variable.InhichChats == "" || variable.InhichChats == " ")
                    variable.InhichChats += idchat;
                else
                    variable.InhichChats += "," + idchat;
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LogOutChat(int idUser, int idchat)
        {
            try
            {
                var variable = _bd.users.Where(x => x.ID == idUser).FirstOrDefault();
                string[] mystring = variable.InhichChats.Split(',');
                string idchat2 = idchat.ToString(), idchat3 = "";
                mystring = mystring.Where(x => x != idchat2).ToArray();
                if (mystring.Length == 0)
                    idchat3 = "";
                else
                    idchat3 += mystring[0];
                for (int i = 1; mystring.Length > i; i++)//11111
                    idchat3 += "," + mystring[i];
                variable.InhichChats = idchat3;
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Users>> Select()
        {
            return await _bd.users.ToListAsync();
        }
    }
}
