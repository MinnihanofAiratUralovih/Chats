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
    public class ContactsRepository : IContactsRepository
    {
        private readonly BDLibreare _bd;

        public ContactsRepository(BDLibreare bd)
        {
            _bd = bd;
        }

        public bool AddFriends(int idUser, int friend)
        {
            try
            {
                var variable = _bd.contacts.Where(x => x.ID == idUser).FirstOrDefault();
                variable.Friends += "," + friend;
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Contacts entity)
        {
            try
            {
                _bd.contacts.Add(entity);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Contacts entity)
        {
            try
            {
                var variable = _bd.storage.Where(x => x.ID == entity.ID).FirstOrDefault();
                _bd.storage.Remove(variable);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFriends(int idUser, int friend)
        {
            try
            {
                var variable = _bd.contacts.Where(x => x.ID == idUser).FirstOrDefault();
                string[] mystring = variable.Friends.Split(',');
                string friend2 = friend.ToString(), friend3 = "";
                mystring = mystring.Where(x => x != friend2).ToArray();
                friend3 += mystring[0];
                for (int i = 1; mystring.Length > i; i++)
                    friend3 += "," + mystring[i];
                variable.Friends = friend3;
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Contacts Get(int id)
        {
            var variable = _bd.contacts.Where(x => x.ID == id)
                   .FirstOrDefault();
            return variable;
        }

        public async Task<List<Contacts>> Select()
        {
            return await _bd.contacts.ToListAsync();
        }
    }
}
