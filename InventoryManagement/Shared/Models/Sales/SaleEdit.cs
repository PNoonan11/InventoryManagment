using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Shared.Models.Sales
{
    public class SaleEdit
    {
        public int Id { get; set; }
        public string ProductSold { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantitySold { get; set; }
        public int LocationSoldFrom { get; set; }
        public DateTimeOffset DateOfSale { get; set; }
        public int CustomerSoldTo { get; set; }
        public string SoldByUserId { get; set; }
    }
}

