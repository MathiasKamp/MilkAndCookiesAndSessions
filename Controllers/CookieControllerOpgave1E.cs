using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    // opgave 1E
    [ApiController]
    [Route("[controller]")]
    public class CookieControllerOpgave1E : Controller
    {
        [HttpGet]
        public string Get(string favoritePet)
        {
            // opgave 1E controller 1
            // create a cookie based on the clients favorite pet 
            Response.Cookies.Append("favoritePet", favoritePet);
            return favoritePet;
        }
    }
}