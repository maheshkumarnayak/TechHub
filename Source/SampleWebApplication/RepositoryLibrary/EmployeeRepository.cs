using EntitiesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public GetEmployeesResponse GetEmployees(GetEmployeesRequest request)
        {
            var isSearchEnable=(int)request.Searchtype>0 && !string.IsNullOrEmpty(request.Searchvalue);
            var filterEmployees = TempEmployeeRepo.employees
                .ConditionalEmployeeWhere(request.Searchtype, request.Searchvalue);
            var filterEmployeesCount = filterEmployees.Count();
            filterEmployees = filterEmployees.OrderEmployeeWhere(request.SortType, request.SortOrder)
                .Skip(request.RecordInPage * (request.PageNumber - 1))
                .Take(request.RecordInPage);
            GetEmployeesResponse res = new GetEmployeesResponse
            {
                Employees = filterEmployees.ToList(),
                PageNumber=request.PageNumber,
                RecordInPage=request.RecordInPage,
                TotalRecord = filterEmployeesCount
            };
            return res;
        }

        
    }

    public static class Extenstions
    {
        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>
                (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool ascending)
        {
            return ascending ? source.OrderBy(keySelector)
                              : source.OrderByDescending(keySelector);
        }

        public static IEnumerable<Employee> ConditionalEmployeeWhere
               (this IEnumerable<Employee> source, SearchSortType type,string searchvalue)
        {
            if (type == SearchSortType.Default)
            {
                return source;
            }
            else if (type == SearchSortType.DesignationType)
            {
                return source.Where(x => x.EmpDesignation.ToString().IndexOf(searchvalue, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
            else if (type == SearchSortType.EmployeeName)
            {
                return source.Where(x => x.Name.IndexOf(searchvalue, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
            else if (type == SearchSortType.EmployeeType)
            {
                return source.Where(x => x.EmpType.ToString().IndexOf(searchvalue, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
            return source;
        }

        public static IEnumerable<Employee> OrderEmployeeWhere
              (this IEnumerable<Employee> source, SearchSortType type, bool isAscending)
        {
            if (type == SearchSortType.Default)
            {
                return source;
            }
            else if (type == SearchSortType.DesignationType)
            {
                return source.OrderByWithDirection(x => x.EmpDesignation,isAscending);
            }
            else if (type == SearchSortType.EmployeeName)
            {
                return source.OrderByWithDirection(x => x.Name, isAscending);
            }
            else if (type == SearchSortType.EmployeeType)
            {
                return source.OrderByWithDirection(x => x.EmpType, isAscending);
            }
            return source;
        }
    }

    public static class TempEmployeeRepo
    {
        public static List<Employee> employees = new List<Employee>();
        private static Random random = new Random((int)DateTime.Now.Ticks);

        static TempEmployeeRepo()
        {
            populateTempEmployee();
        }

        private static void populateTempEmployee()
        {
            Random rnd = new Random();
            for (int i = 01; i <= 1000; i++)
            {
                employees.Add(new Employee { Id = i, Name = "Employee" + RandomString(5), EmpDesignation = (Designation)rnd.Next(5), EmpType = (EmployeeType)rnd.Next(2) });
            }
        }


        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
    
}
