
using OAuth.Repository.Entities;
using System;
using System.Linq;
namespace OAuth.Repository.Repository
{
    public interface IAccountRepository : IDisposable
    {
        int CreateUser(User obj);
        int UpdateUser(User obj);
        IQueryable<User> GetAllUser();
        User GetUser(int Id);
        int DeleteUser(User obj);


        int CreateExternalUserLogin(ExternalUserLogin obj);
        int UpdateExternalUserLogin(ExternalUserLogin obj);
        IQueryable<ExternalUserLogin> GetAllExternalUserLogin();
        ExternalUserLogin GetExternalUserLogin(int Id);
        int DeleteExternalUserLogin(ExternalUserLogin obj);


        int CreateClient(Client obj);
        int UpdateClient(Client obj);
        IQueryable<Client> GetAllClient();
        Client GetClient(string Id);
        int DeleteClient(Client obj);


        int CreateRefreshToken(RefreshToken obj);
        int UpdateRefreshToken(RefreshToken obj);
        IQueryable<RefreshToken> GetAllRefreshToken();
        RefreshToken GetRefreshToken(string Id);
        int DeleteRefreshToken(RefreshToken obj);
    }
}
