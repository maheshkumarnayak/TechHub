
using OAuth.Repository.Context;
using OAuth.Repository.Entities;
using System;
using System.Linq;
namespace OAuth.Repository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private OAuthContext _ctx;
        public AccountRepository()
        {
            _ctx = new OAuthContext();
        }

        #region User
        public int CreateUser(User obj)
        {
            _ctx.Users.Add(obj);
            return _ctx.SaveChanges();
        }
        public int UpdateUser(User obj)
        {
            _ctx.Users.Add(obj);
            return _ctx.SaveChanges();
        }
        public IQueryable<User> GetAllUser()
        {
            return _ctx.Users;
        }
        public User GetUser(int Id)
        {
            return _ctx.Users.Find(Id);
        }
        public int DeleteUser(User obj)
        {
            _ctx.Users.Remove(obj);
            return _ctx.SaveChanges();
        } 
        #endregion

        #region ExternalUserLogin
        public int CreateExternalUserLogin(ExternalUserLogin obj)
        {
            _ctx.ExternalUserLogins.Add(obj);
            return _ctx.SaveChanges();
        }
        public int UpdateExternalUserLogin(ExternalUserLogin obj)
        {
            _ctx.ExternalUserLogins.Add(obj);
            return _ctx.SaveChanges();
        }
        public IQueryable<ExternalUserLogin> GetAllExternalUserLogin()
        {
            return _ctx.ExternalUserLogins;
        }
        public ExternalUserLogin GetExternalUserLogin(int Id)
        {
            return _ctx.ExternalUserLogins.Find(Id);
        }
        public int DeleteExternalUserLogin(ExternalUserLogin obj)
        {
            _ctx.ExternalUserLogins.Remove(obj);
            return _ctx.SaveChanges();
        }
        #endregion

        #region Client
        public int CreateClient(Client obj)
        {
            _ctx.Clients.Add(obj);
            return _ctx.SaveChanges();
        }
        public int UpdateClient(Client obj)
        {
            _ctx.Clients.Add(obj);
            return _ctx.SaveChanges();
        }
        public IQueryable<Client> GetAllClient()
        {
            return _ctx.Clients;
        }
        public Client GetClient(string Id)
        {
            return _ctx.Clients.Find(Id);
        }
        public int DeleteClient(Client obj)
        {
            _ctx.Clients.Remove(obj);
            return _ctx.SaveChanges();
        }
        #endregion

        #region RefreshToken
        public int CreateRefreshToken(RefreshToken obj)
        {
            _ctx.RefreshTokens.Add(obj);
            return _ctx.SaveChanges();
        }
        public int UpdateRefreshToken(RefreshToken obj)
        {
            _ctx.RefreshTokens.Add(obj);
            return _ctx.SaveChanges();
        }
        public IQueryable<RefreshToken> GetAllRefreshToken()
        {
            return _ctx.RefreshTokens;
        }
        public RefreshToken GetRefreshToken(string Id)
        {
            return _ctx.RefreshTokens.Find(Id);
        }
        public int DeleteRefreshToken(RefreshToken obj)
        {
            _ctx.RefreshTokens.Remove(obj);
            return _ctx.SaveChanges();
        }
        #endregion

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ctx.Dispose();
            }
        }

        public void Dispose()
        {
             _ctx.Dispose();
        }
    }
}
