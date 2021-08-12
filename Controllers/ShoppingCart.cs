using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    // opgave 2B
    // opgave 2C i can confirm that i can see the session cookie at the clients site in the browser
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCart : Controller
    {
        [HttpGet]
        public IEnumerable Get(string name, double price)
        {
            // fetch shoppingCart from session 
            List<Product> shoppingCart = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");
            // create temp product to be added to the list later
            var tmpProduct = new Product(name, price);

            // check if the shoppingCart not empty
            if (shoppingCart != null)
            {
                // add the new product to the shoppingCart
                shoppingCart.Add(tmpProduct);
                // add the shoppingCart to the session
                HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart);
            }

            else
            {
                // create new shoppingCart
                shoppingCart = new List<Product>();
                // add the product to the list
                shoppingCart.Add(tmpProduct);
                // add the shoppingCart to session
                HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart);
            }

            // return the shoppingCart to the client
            return shoppingCart;
        }

        // this method returns the shoppingCart from the session
        [HttpGet]
        [Route("fetch-shoppingCart-from-session")]
        public List<Product> GetShoppingCart()
        {
            // gets the shoppingCart back from the session and converts it from Json List<Product>
            var shoppingCart = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");

            return shoppingCart;
        }
    }
}