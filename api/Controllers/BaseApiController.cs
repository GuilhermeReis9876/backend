using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private readonly ILogger<BaseApiController> _logger;
        private IMapper _mapper;

        public BaseApiController(ILogger<BaseApiController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
