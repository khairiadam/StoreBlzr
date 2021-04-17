using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Authentication;
using Shared.Dto;

namespace StoreBlzr.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        #region Registration Method (Create Token and register user)


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserModel model)
        {
            //Check the Model State(Annotaions)
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //Register User and Get the Result
            var result = await _authService.RegisterAsync(model);

            //In case Some error => BadRequest
            if (!result.IsAuthenticated) return BadRequest(result.Message);

            //In case success return Ok with the result OR Object with some info (Needed!)
            //return Ok(new {Token = result.Token , ExpiresOn= result.ExpiresOn});
            return Ok(result);

        }


        #endregion





        #region Login Method (Get Token)


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login model)
        {
            //Check the Model State(Annotaions)
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //Login User and Get the Result
            var result = await _authService.GetTokenAsync(model);

            //In case Some error => BadRequest
            if (!result.IsAuthenticated) return BadRequest(result.Message);

            //In case success return Ok with the result OR Object with some info (Needed!)
            //return Ok(new {Token = result.Token , ExpiresOn= result.ExpiresOn});
            return Ok(result);
        }


        #endregion


    }


}