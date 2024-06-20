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
    public class NotificationsRepository : INotificationsRepository
    {
        private readonly BDLibreare _bd;

        public NotificationsRepository(BDLibreare bd)
        {
            _bd = bd;
        }

        public bool Create(Notifications entity)
        {
            try
            {
                _bd.notifications.Add(entity);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Notifications entity)
        {
            try
            {
                var variable = _bd.notifications.Where(x => x.ID == entity.ID).FirstOrDefault();
                _bd.notifications.Remove(variable);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Notifications Get(int id)
        {
            var variable = _bd.notifications.Where(x => x.ID == id)
                   .FirstOrDefault();
            return variable;
        }

        public async Task<List<Notifications>> Select()
        {
            return await _bd.notifications.ToListAsync();
        }

        public bool ToAccept(int notification)
        {
            try
            {
                var variable = _bd.notifications.Where(x => x.ID == notification).FirstOrDefault();
                _bd.notifications.Remove(variable);
                _bd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
