using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BethanysPieShop.Controllers
{
    // Controller to handle order-related actions
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        // Constructor for dependency injection
        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        // Displays the checkout page (GET request by default)
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost] // Defines an HTTP POST request for form submission
        public IActionResult Checkout(Order order) 
        {
            // Retrieve the items currently in the shopping cart
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            // Check if the shopping cart is empty
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                // Add a validation error if the cart is empty
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            // If the model state is valid (no errors), process the order
            if (ModelState.IsValid)
            {
                // Save the order to the database
                _orderRepository.CreateOrder(order);
                
                // Clear the shopping cart after successful order placement
                _shoppingCart.ClearCart();
                
                // Redirect the user to the checkout completion page
                return RedirectToAction("CheckoutComplete");
            }

            // If there are validation errors, return the checkout view with the order details
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage =  "Thanks for your order. You'll soon enjoy our delicious pies !";
            return View();
        }
    }
}
