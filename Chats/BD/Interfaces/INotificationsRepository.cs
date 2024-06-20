using BD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Interfaces
{
    public interface INotificationsRepository : IBaseRepository<Notifications>
    {
        bool ToAccept(int notification);//принять уведомление
    }
}
