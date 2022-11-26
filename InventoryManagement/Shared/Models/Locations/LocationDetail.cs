using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Shared.Models.Locations
{
    public class LocationDetail
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int CountOfProducts { get; set; }

    }
}
