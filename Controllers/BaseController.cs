using ELearningPlatform.Models.CommonModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ELearningPlatform.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public ActionResult BaseResult(ApiResponse? data = null)
        {
            if (data == null)
            {
                return Ok();
            }

            return data.status switch
            {
                (int)HttpStatusCode.OK => Ok(data),
                (int)HttpStatusCode.BadRequest => BadRequest(data),
                (int)HttpStatusCode.UnprocessableEntity => UnprocessableEntity(data),
                (int)HttpStatusCode.Unauthorized or (int)HttpStatusCode.Forbidden => Unauthorized(data),
                (int)HttpStatusCode.NotFound => NotFound(data),
                _ => StatusCode(data.status, data),
            };
        }
    }
}
