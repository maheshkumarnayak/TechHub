using EntitiesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class GetEmployeesResponseModel
    {

        public GetEmployeesResponseModel(GetEmployeesResponse obj)
        {
            PageNumber = obj.PageNumber;
            RecordInPage = obj.RecordInPage;
            TotalRecord = obj.TotalRecord;
            Employees = obj.Employees.Select(x => new EmployeeModel
            {
                EmpDesignation = x.EmpDesignation.ToString(),
                EmpType = x.EmpType.ToString(),
                Name = x.Name,
                Id = x.Id
            }).ToList();
        }

        public List<EmployeeModel> Employees { get; set; }

        public int PageNumber { get; set; }

        public int RecordInPage { get; set; }

        public int TotalRecord { get; set; }
    }
}