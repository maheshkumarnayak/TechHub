using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLibrary
{
    [DataContract]
    public enum SearchSortType
    {
        [EnumMember]
        Default,
        [EnumMember]
        EmployeeType,
        [EnumMember]
        DesignationType,
        [EnumMember]
        EmployeeName
    }
}
