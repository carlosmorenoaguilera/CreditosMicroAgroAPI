using CreditosMicroAgroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditosMicroAgroAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings jwtSettings;
        private readonly CreditosMicroAgroContext _context;

        public AuthController(JwtSettings jwtSettings, CreditosMicroAgroContext context)
        {
            this._context = context;
            this.jwtSettings = jwtSettings;
        }
        [HttpPost]
        public async Task<ActionResult<UserTokens>> GetToken(UserAuthRequest user)
        {
            var Token = new UserTokens();
            var UserState = _context.Empleados.FirstOrDefault(s => (s.Username == user.UserName) && (s.Password == user.Password));
            if (UserState != null)
            {

                Token = JwtHelpers.JWTHelpers.GenTokenkey(new UserTokens()
                {
                    EmailId = UserState.Email,
                    GuidId = Guid.NewGuid(),
                    UserName = UserState.Username,
                    Id = UserState.IdGuid.Value,
                    Role =  UserState.Tipo,


                }, jwtSettings);
                return Token;
            }
            return BadRequest();
        }
                                
    }
}
