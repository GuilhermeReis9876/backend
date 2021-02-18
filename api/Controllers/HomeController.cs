using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    public class HomeController : BaseApiController
    {


        public HomeController(
            ILogger<HomeController> logger,
            IMapper mapper
            ) :
            base(logger, mapper)
        { }

        [HttpGet]
        [Route("/")]
        [AllowAnonymous]
        public IActionResult Home()
        {
            return Redirect("/swagger/index.html");
        }

    }
}
