using OAuth.Repository.Repository;
using System.Web.Http;

namespace OAuth.Api.Controllers
{
    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : ApiController
    {

        private IAccountRepository _repo;
        public RefreshTokensController()
        {
            _repo = new AccountRepository();
        }

        [Authorize(Users = "Admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_repo.GetAllRefreshToken());
        }


        [AllowAnonymous]
        [Route("")]
        public IHttpActionResult Delete(string tokenId)
        {
            var refreshToken = _repo.GetRefreshToken(tokenId);
            var result = _repo.DeleteRefreshToken(refreshToken);
            if (result>0)
            {
                return Ok();
            }
            return BadRequest("Token Id does not exist");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
