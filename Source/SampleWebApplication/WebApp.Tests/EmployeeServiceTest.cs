using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using EntitiesLibrary;
using WebApp.Models;

namespace WebApp.Tests
{
    [TestClass]
    public class EmployeeServiceTest
    {
        [TestMethod]
        public void GetEmployeePageCount()
        {
            var controller = new EmployeeController();
            GetEmployeesRequest request = new GetEmployeesRequest
            {
                PageNumber = 1,
                RecordInPage = 15,
                Searchtype = SearchSortType.Default,
                SortType = SearchSortType.Default
            };
            var result = controller.Get(request) as GetEmployeesResponseModel;
            Assert.AreEqual(15, result.RecordInPage);

        }


        [TestMethod]
        public void CheckSearchByDesignation()
        {
            var controller = new EmployeeController();
            GetEmployeesRequest request = new GetEmployeesRequest
            {
                PageNumber = 1,
                RecordInPage = 10,
                Searchtype = SearchSortType.DesignationType,
                Searchvalue="Lead",
                SortType = SearchSortType.Default
            };
            var result = controller.Get(request) as GetEmployeesResponseModel;
            Assert.AreEqual("Lead", result.Employees[0].EmpDesignation);

        }


        [TestMethod]
        public void CheckSearchByEmpType()
        {
            var controller = new EmployeeController();
            GetEmployeesRequest request = new GetEmployeesRequest
            {
                PageNumber = 1,
                RecordInPage = 10,
                Searchtype = SearchSortType.EmployeeType,
                Searchvalue = "Permanent",
                SortType = SearchSortType.Default
            };
            var result = controller.Get(request) as GetEmployeesResponseModel;
            Assert.AreEqual("Permanent", result.Employees[0].EmpType);

        }



    }
}
