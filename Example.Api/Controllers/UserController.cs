using Exp.Isis.CrisisManager.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public bool IsAuthenticated { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet("current")]
        public UserInfo CurrentUser()
        {
            return new UserInfo
            {
                Id = _identityService.GetId(),
                Login = _identityService.GetMail(),
                IsAuthenticated = _identityService.IsAuthenticated()
            };
        }
    }
}
