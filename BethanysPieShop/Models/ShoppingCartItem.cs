using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    // Defines a class representing an item in a shopping cart
    public class ShoppingCartItem
    {
        // Unique identifier for the shopping cart item
        public int ShoppingCartItemId { get; set; }

        // Reference to the Pie object associated with this cart item
        public Pie Pie { get; set; } = default!; 

        // Quantity of this pie in the shopping cart
        public int Amount { get; set; }

        // Identifier for the shopping cart (useful for multi-user scenarios)
        public string ShoppingCartId { get; set; }
    }
}