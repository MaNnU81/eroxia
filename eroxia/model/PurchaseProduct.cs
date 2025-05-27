using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia.model
{
    internal class PurchaseProduct
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public decimal TotalPrice => Quantity * Product.Price;

        public PurchaseProduct(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }
       

        //public Purchase Purchase { get; set; }
    }
}
