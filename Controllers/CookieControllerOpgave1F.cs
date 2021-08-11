using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    // opgave 1F 
    [ApiController]
    [Route("[controller]")]
    public class CookieControllerOpgave1F : Controller
    {
        // this method creates a cookie called favoritePet and adds 5 minute expiry date on it.
        [HttpGet]
        public string Get(string favoritePet)
        {
            
            CookieOptions cookieOptions = new CookieOptions();
            DateTime dateTime = DateTime.Now;
            cookieOptions.Expires = dateTime.AddMinutes(5);
            Response.Cookies.Append("favoritePet", favoritePet,cookieOptions);
            return favoritePet;
        }

        // this method gets the favoritePet cookie and subtracts 100 minutes from the expiry date
        // which results in the cookie is no longer active
        [HttpGet]
        [Route("[action]")]
        public string ChangeExpiryDate()
        {
            DateTime dateTime = DateTime.Now;
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = dateTime.AddMinutes(-100);
            var favoritePetValue = Request.Cookies["favoritePet"];
            Response.Cookies.Append("favoritePet",favoritePetValue,cookieOptions);

            return favoritePetValue;
        }
    }
}