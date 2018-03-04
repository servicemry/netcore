using System;
using working.Models.DataModel;
namespace working.Models.Repository
{
    public interface IUserRepository
    {
        UserRole Login(string userName, string password);
    }
}
