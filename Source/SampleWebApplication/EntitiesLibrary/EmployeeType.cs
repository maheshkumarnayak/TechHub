using System.Runtime.Serialization;

namespace EntitiesLibrary
{
    [DataContract]
    public enum EmployeeType
    {
        [EnumMember]
        Permanent,
        [EnumMember]
        Contractual
    }
}
