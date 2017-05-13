using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuth.Repository.Entities
{
    public class ExternalUserLogin
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string LoginProvider { get; set; }
        [Key]
        [Column(Order = 3)]
        public string ProviderKey { get; set; }

    }
}
