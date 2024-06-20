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
    public class StorageRepository : IStorageRepository
    {
        private readonly BDLibreare _bd;

        public StorageRepository(BDLibreare bd)
        {
            _bd = bd;
        }

        public bool Create(Storage entity)
        {
            try
            {
                _bd.storage.Add(entity);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Storage entity)
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

        public bool EditMessage(int id, string txt)
        {
            try
            {
                var variable = _bd.storage.Where(x => x.ID == id).FirstOrDefault();
                variable.Text = txt;
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Storage Get(int id)
        {
            var variable = _bd.storage.Where(x => x.ID == id)
                .Include(y => y.IDUsers)
                  .FirstOrDefault();
            return variable;
        }

        public List<Storage> Return10Messages(int idchat, int extreme)
        {
            var variable = _bd.storage.Where(x => x.ID == idchat);
            List<Storage> Storage2 = new List<Storage>();
            int cycle = 0;
            if (extreme == 0)
            {
                foreach (var i in variable.Reverse())
                {
                    cycle++;
                    Storage2.Add(i);
                    _bd.SaveChanges();
                    if (cycle == 10)
                        break;
                }
            }
            else
            {
                var variable2 = variable.Where(x => x.ID < extreme);
                foreach (var i in variable2.Reverse())
                {
                    cycle++;
                    Storage2.Add(i);
                    _bd.SaveChanges();
                    if (cycle == 10)
                        break;
                }
            }
            return Storage2;
        }

        public async Task<List<Storage>> Select()
        {
            return await _bd.storage.ToListAsync();
        }

        public string Select2(string idchat)
        {
            var variable = _bd.storage.Where(x => x.IDChats.ID == Convert.ToInt32(idchat));
            int totalCount = _bd.storage.Count(x => x.IDChats.ID == Convert.ToInt32(idchat));
            if (totalCount > 10)
                variable = (IQueryable<Storage>)_bd.storage.Where(x => x.IDChats.ID == Convert.ToInt32(idchat)).Where(x => x.IDChats.ID == Convert.ToInt32(idchat)).Skip(totalCount - 10);
            else
            { }
            string name = "", name2 = "";
            int j = 0;
            int[] mas1 = new int[10];
            foreach (var i in variable)
            {
                //name += i.ID + " ";
                mas1[j] = i.ID;
                j++;
            }
            j = 0;
            foreach (var i in mas1)
            {
                if (i.ToString() != "")
                {
                    j++;
                    name += i + " ";
                    name2 += i + " ";
                    if (j == 10)
                    {
                        char[] charArray = name2.ToCharArray();
                        Array.Reverse(charArray);
                        string reversedString = new string(charArray);
                        return name2;
                    }
                }
            }
            return name;
        }

        public string Size(string idchat)
        {
            var variable = _bd.storage.Where(x => x.ID.ToString() == idchat);
            foreach (var i in variable.Reverse())
                return i.ID.ToString();
            return "";
        }
    }
}
