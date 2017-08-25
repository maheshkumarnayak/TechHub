using EntitiesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WCFServiceContract;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : ApiController
    {

        public GetEmployeesResponseModel Get([FromUri]GetEmployeesRequest request)
        {
            try
            {
                return getEmployees(request);
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }

        private GetEmployeesResponseModel getEmployees(GetEmployeesRequest request)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["wcfseviceendpoint"].ToString());
            var factory = new ChannelFactory<IEmployeeService>(binding, address);
            IEmployeeService channel = factory.CreateChannel();
            GetEmployeesResponse result = channel.GetEmployees(request);
            return new GetEmployeesResponseModel(result);
        }

    }
}