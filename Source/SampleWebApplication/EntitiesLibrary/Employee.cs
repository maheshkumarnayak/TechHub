using System.Runtime.Serialization;

namespace EntitiesLibrary
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public EmployeeType EmpType { get; set; }

        [DataMember]
        public Designation EmpDesignation { get; set; }
    }
}
