using EntitiesLibrary;
using System.Collections.Generic;

namespace RepositoryLibrary
{    
    public interface IEmployeeRepository
    {
        GetEmployeesResponse GetEmployees(GetEmployeesRequest request);
    }
}
