using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using OAuth.Api.Models;
using OAuth.Repository.Entities;
using OAuth.Repository.Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OAuth.Api.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {

        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return Task.FromResult(0);
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            using (IAccountRepository _repo = new AccountRepository())
            {
                var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime"); 
               
                var token = new RefreshToken() 
                { 
                    Id = Helper.GetHash(refreshTokenId),
                    ClientId = clientid, 
                    Subject = context.Ticket.Identity.Name,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime)) 
                };

                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;
                
                token.ProtectedTicket = context.SerializeTicket();

                var result = _repo.CreateRefreshToken(token);

                if (result>0)
                {
                    context.SetToken(refreshTokenId);
                }
             
            }
            return Task.FromResult(0);
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {

            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string hashedTokenId = Helper.GetHash(context.Token);

            using (IAccountRepository _repo = new AccountRepository())
            {
                var refreshToken = _repo.GetRefreshToken(hashedTokenId);

                if (refreshToken != null )
                {
                    //Get protectedTicket from refreshToken class
                    context.DeserializeTicket(refreshToken.ProtectedTicket);
                    var result = _repo.DeleteRefreshToken(refreshToken);
                }
            }
            return Task.FromResult(0);
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}