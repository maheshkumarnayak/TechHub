using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Repository.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        [MaxLength(200)]
        public string CustomerName { get; set; }
        public string ShipperCity { get; set; }
        public Boolean IsShipped { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDetails { get; set; }
    }
}
