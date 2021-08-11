using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookieController1E_2 : Controller
    {
        // opgave 1E
        [HttpGet]
        [Route("[action]")]
        public string GetFromCookieController1E()
        {
            // opgave 1E controller 2. receives the cookie correctly from controller -> CookieControllerOpgave1E
            var cookieData = Request.Cookies["favoritePet"];

            if (cookieData.Length > 0)
            {
                return cookieData;
            }
            
            return "unknown";
        }
    }
}