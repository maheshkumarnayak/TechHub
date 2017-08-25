using EntitiesLibrary;
using RepositoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFServiceContract;

namespace WCFService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService()
        {
            _repo = new EmployeeRepository();
        }

        public GetEmployeesResponse GetEmployees(GetEmployeesRequest request)
        {
            return _repo.GetEmployees(request);
        }
    }
}
