using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public interface IUserRepository
    {
        Task<HttpResponseMessage> Register(string teamName, string password, List<User> users);
        Task<HttpResponseMessage> Login(string teamName, string password);
    }
}
