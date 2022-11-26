using InventoryManagement.Shared.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryManagement.Shared.Models.Customers
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
       // public ICollection<ProductsSold> ItemsPurchased { get; set; }
    }
}

