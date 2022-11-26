using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Server.Models
{
    public class LocationEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual ICollection<ProductInLocations> ListOfLocations { get; set; }


    }
}
