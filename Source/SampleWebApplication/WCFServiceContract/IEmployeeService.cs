using EntitiesLibrary;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFServiceContract
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        GetEmployeesResponse GetEmployees(GetEmployeesRequest request);
    }
}
