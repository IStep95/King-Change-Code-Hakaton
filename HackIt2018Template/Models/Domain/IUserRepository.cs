using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public interface IUserRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEvent(int id);
    }
}
