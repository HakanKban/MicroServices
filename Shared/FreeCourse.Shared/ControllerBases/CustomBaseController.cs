using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreeCourse.Shared.ControllerBases
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(ResponseDTO<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
