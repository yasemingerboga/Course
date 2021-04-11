using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationsController : ControllerBase
    {
        IUserInformationService _userInformationService;

        public UserInformationsController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }
 
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userInformationService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(UserInformation userInformation)
        {
            var result = _userInformationService.Add(userInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(UserInformation userInformation)
        {
            var result = _userInformationService.Delete(userInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(UserInformation userInformation)
        {
            var result = _userInformationService.Update(userInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
