using System.Runtime.Serialization;

namespace EntitiesLibrary
{
    [DataContract]
    public enum Designation
    {
        [EnumMember]
        Intern,
        [EnumMember]
        SoftwareEngineer,
        [EnumMember]
        Lead,
        [EnumMember]
        Manager,
        [EnumMember]
        Director
    }
}
