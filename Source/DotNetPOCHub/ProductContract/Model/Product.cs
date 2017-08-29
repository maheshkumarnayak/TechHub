using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ProductContract.Model
{
    [DataContract (Namespace="myModel")]
    public class Product
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Descripation { get; set; }

        [Required]
        [DataMember]
        public double CPU { get; set; }

        [Required]
        [DataMember]
        public float DiscountPer { get; set; }

    }
}
