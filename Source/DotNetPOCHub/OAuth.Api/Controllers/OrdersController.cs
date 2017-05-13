using OAuth.Repository.Repository;
using System.Web.Http;

namespace OAuth.Api.Controllers
{
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        private IOrderRepository _repo;
        public OrdersController()
        {
            _repo = new OrderRepository();
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_repo.GetAllOrder());
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
