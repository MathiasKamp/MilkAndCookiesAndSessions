using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookieControllerOpgave1 : Controller
    {
        // opgave 1A this method returns the string that the user inserts in the url as parameter 
        [HttpGet]
        public string Get(string favoriteMilkShake)
        {
            
            CookieOptions cookieOptions = new CookieOptions();
            DateTime dateTime = DateTime.Now;
            // opgave 1C add 5 minute expiry time to the cookie.
            cookieOptions.Expires = dateTime.AddMinutes(5);
            // opgave 1B this line of code, adds the value of favoriteMilkShake from the client to their cookie
            Response.Cookies.Append("favoriteMilkShake", favoriteMilkShake, cookieOptions);
            return favoriteMilkShake;
        }

        
        // ogave 1C this method gets the value of the parameter favoriteMilkShake on the clients cookie
        [HttpGet]
        [Route("[action]")]
        public string GetFromCookie()
        {
            var cookieData = Request.Cookies["favoriteMilkShake"];

            if (cookieData.Length > 0)
            {
                return cookieData;
            }
            
            return "unknown";
        }
        
        
    }
}