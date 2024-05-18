using Microsoft.AspNetCore.Mvc;
using Nowadays.DataAccess.Dtos.Response;

namespace Nowadays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<TEntity>(ResponseDto<TEntity> response) where TEntity : class
        {
                  
            return new ObjectResult(response)
            {
                StatusCode = response.status
            };
        }
    }
}
