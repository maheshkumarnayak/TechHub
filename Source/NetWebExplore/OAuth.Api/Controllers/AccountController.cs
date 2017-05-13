using OAuth.Api.Models;
using OAuth.Repository.Entities;
using OAuth.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OAuth.Api.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {

        private IAccountRepository _repo;
        public AccountController()
        {
            _repo = new AccountRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int result = _repo.CreateUser(new User 
            {
                Name= userModel.UserName,
                Secret=Helper.GetHash(userModel.Password),
                UserName= userModel.UserName
            });

            if (result<=0)
            {
                return BadRequest();
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
