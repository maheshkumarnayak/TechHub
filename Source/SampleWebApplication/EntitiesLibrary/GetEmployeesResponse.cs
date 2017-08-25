using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLibrary
{
    [DataContract]
    public class GetEmployeesResponse
    {
        [DataMember]
        public List<Employee> Employees { get; set; }

        [DataMember]
        public int PageNumber { get; set; }

        [DataMember]
        public int RecordInPage { get; set; }

        [DataMember]
        public int TotalRecord { get; set; }
    }
}
