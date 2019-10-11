using Bazzar.Core.ApplicationServices.UserProfiles.CommandHandlers;
using Bazzar.Core.Domain.UserProfiles.Commands;
using Bazzar.EndPoints.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bazzar.EndPoints.API.Controllers
{
    [ApiController]
    [Route("/profile")]
    public class UserProfileController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromServices] RegisterUserHandler registerUserHandler,
                                  RegisterUser request)
        {
            return RequestHandler.HandleRequest(request, registerUserHandler.Handle);
        }
        [Route("name")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateUserNameHandler updateUserNameHandler,
                                 UpdateUserName request)
        {
            return RequestHandler.HandleRequest(request, updateUserNameHandler.Handle);
        }
        [Route("displayname")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateUserDisplayNameHandler updateUserDisplayNameHandler,
                                 UpdateUserDisplayName request)
        {
            return RequestHandler.HandleRequest(request, updateUserDisplayNameHandler.Handle);
        }

        [Route("email")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateUserEmailHandler updateUserEmailHandler,
                         UpdateUserEmail request)
        {
            return RequestHandler.HandleRequest(request, updateUserEmailHandler.Handle);
        }
    }
}
