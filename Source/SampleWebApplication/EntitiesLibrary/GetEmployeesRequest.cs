using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLibrary
{
    [DataContract]
    public class GetEmployeesRequest
    {
        [DataMember]
        public int PageNumber { get; set; }

        [DataMember]
        public int RecordInPage { get; set; }

        [DataMember]
        public SearchSortType Searchtype  { get; set; }

        [DataMember]
        public string Searchvalue { get; set; }

        [DataMember]
        public SearchSortType SortType { get; set; }

        [DataMember]
        public bool SortOrder { get; set; }
    }
}
