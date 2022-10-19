using FromDatabaseToTemplate.DAL;
using FromDatabaseToTemplate.Entities;
using FromDatabaseToTemplate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace FromDatabaseToTemplate.Controllers
{


    [ApiController]
    [Route("api/user")]


    public class UserController : ControllerBase
    {
        private readonly IUserServices _userInterface;

        public UserController(IUserServices userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        public async  Task<ActionResult<string>> Get(string policyNumber, string productNumber)
        {
            string content;
          
            try
            {
               content = await _userInterface.GetUser(policyNumber, productNumber);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            };

            return new ContentResult
            {
                ContentType = "text/html",
                Content = content
            };

           
        }

        [HttpGet("AllUsers")]
        public async Task<ContentResult> GetAllUsers()
        {
            string content;
            var response = new HttpResponseMessage();

            try
            {
                content = await _userInterface.GetUsers();
            }
            catch (Exception ex)
            {

                return base.Content(ex.Message);
               
            };

            return new ContentResult
            {
                ContentType = "text/html",
                Content = content
            };

            //return base.Content(content);


            

           
        }



    }
}
