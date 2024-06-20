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
    public class ChatsRepository : IChatsRepository
    {
        private readonly BDLibreare _bd;

        public ChatsRepository(BDLibreare bd)
        {
            _bd = bd;
        }

        public bool AddUser(int idchat, int idUser)
        {
            try
            {
                var variable = _bd.chats.Where(x => x.ID == idchat).FirstOrDefault();
                variable.IDUsers += "," + idUser;
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeTheCreator(int idchat, int idUser)
        {
            try
            {
                var variable = _bd.chats.Where(x => x.ID == idchat).FirstOrDefault();
                variable.Сreator = idUser.ToString();
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeTheName(int idchat, string name)
        {
            try
            {
                var variable = _bd.chats.Where(x => x.ID == idchat).FirstOrDefault();
                variable.Name = name;
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Chats entity)
        {
            try
            {
                _bd.chats.Add(entity);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Chats entity)
        {
            try
            {
                var variable = _bd.chats.Where(x => x.ID == entity.ID).FirstOrDefault();
                _bd.chats.Remove(variable);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(int idchat, int idUser)
        {
            try
            {
                var variable = _bd.chats.Where(x => x.ID == idchat).FirstOrDefault();
                string[] mystring = variable.IDUsers.Split(',');
                string idUser2 = idUser.ToString(), idUser3 = "";
                mystring = mystring.Where(x => x != idUser2).ToArray();
                idUser3 += mystring[0];
                for (int i = 1; mystring.Length > i; i++)
                    idUser3 += "," + mystring[i];
                variable.IDUsers = idUser3;
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Chats Get(int id)
        {
            var variable = _bd.chats.Where(x => x.ID == id)
                .FirstOrDefault();
            return variable;
        }

        public async Task<List<Chats>> Select()
        {
            return await _bd.chats.ToListAsync();
        }

        public string SelectID()
        {
            int totalCount = _bd.chats.Count(x => x.ID != -1);
            var lastElement = _bd.chats.OrderByDescending(e => e.ID).FirstOrDefault();
            int lastElement2 = lastElement.ID;
            return lastElement2.ToString();
        }
    }
}
