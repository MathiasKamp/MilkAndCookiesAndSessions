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
        private IList<Product> shoppingCart = new List<Product>();
        
        
        [HttpGet]
        public IEnumerable Get(string name, double price)
        {
            // testing purposes of 2E as i don't know how i can add more than 1 product to the list
            var testOpgave2E = new Product("test",1000);
            // create temp product to be added to the list later
            var tmpProduct = new Product(name, price);
            
            // add the product to the list
            shoppingCart.Add(tmpProduct);
            shoppingCart.Add(testOpgave2E);
            // puts the shoppingCart into the session as a json string
            HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart);
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