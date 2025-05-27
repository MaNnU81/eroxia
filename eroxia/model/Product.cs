using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia.model
{
    internal class Product
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Material { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public string? Color { get; set; }

        //enum Category
        //{
        //    vibratori = 1,
        //    dildo = 2,
        //    lube = 3,
        //    bondage = 4,
        //    flashlight = 5,
        //    edible = 6,
        //    plug = 7,
        //    cosplay = 8,
        //    condom = 9,
        //    alien = 10
        //}

        public Product(int productId, string name, string manufacturer, decimal price)
        {
            ProductId = productId;
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            
        }
    }
}
