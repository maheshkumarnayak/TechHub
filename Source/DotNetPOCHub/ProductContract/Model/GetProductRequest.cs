using System.Runtime.Serialization;

namespace ProductContract.Model
{
    [DataContract]
    public class GetProductRequest
    {
        [DataMember]
        public int PageNumber { get; set; }

        [DataMember]
        public int RecordInPage { get; set; }
    }
}
