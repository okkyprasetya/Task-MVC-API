using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;

namespace MyRESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleBLL _roleBLL;

        public RoleController(IRoleBLL roleBLL)
        {
            _roleBLL = roleBLL;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addtorole")]
        public async Task<ActionResult> AddToRole([FromBody] UsersRolesDTO userRoleRequest)
        {
            try
            {
                await _roleBLL.AddUserToRole(userRoleRequest.Username, userRoleRequest.RoleID);
                return Ok("User added to role successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Error adding user to role: " + ex.Message);
            }
        }
    }
}
