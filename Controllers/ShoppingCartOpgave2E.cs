using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    // opgave 2E
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartOpgave2E : Controller
    {
        // method deletes a given object from the shoppingCart list in the session and returns the shopping cart
        [HttpDelete]
        public List<Product> DeleteFromShoppingCart(string name)
        {
            var shoppingCart = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");
            bool productExists = false;

            if (shoppingCart.Count > 0)
            {
                foreach (var product in shoppingCart)
                {
                    if (product.Name == name)
                    {
                        productExists = true;
                    }
                }
            }
            
            if (productExists)
            {
                shoppingCart.RemoveAll(x=> x.Name == name);
            }
            
            HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart);

            return shoppingCart;
        }
    }
}