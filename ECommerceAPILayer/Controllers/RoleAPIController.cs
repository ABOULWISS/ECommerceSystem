using ECommerceContractLair;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ECommerceUseCaseLair;

namespace ECommerceAPILayer {

    [ApiController]
    [Route("api/roles")]
    [EnableCors("UseCors")]
    [Authorize]
    public sealed class RoleController : ControllerBase
    {
        private  readonly IRoleUseCaseFacade _roles;
    
        public RoleController(IRoleUseCaseFacade roles)
            => _roles = roles ?? throw new ArgumentNullException(nameof(roles));
    
        // GET: api/roles/by-name/Admin
        [HttpGet("by-name/{roleName}")]
        [ProducesResponseType(typeof(RoleCoreDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoleCoreDTO>> GetByName(string roleName, CancellationToken ct)
        {
            var role = await _roles.GetRoleByName(roleName, ct);
            return role is null ? NotFound() : Ok(role);
        }
    
        // GET: api/users/5/roles
        [HttpGet("~/api/users/{userId:int}/roles")]
        [ProducesResponseType(typeof(IReadOnlyList<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<string>>> GetUserRoles(int userId, CancellationToken ct)
        {
            var roles = await _roles.GetRolesForUser(userId, ct);
            return Ok(roles);
        }
    
        // PUT: api/users/5/roles/2
        [HttpPut("~/api/users/{userId:int}/roles/{roleId:int}")]
        //[Authorize(Policy = "RoleManage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AssignRoleToUser(int userId, int roleId, CancellationToken ct)
        {
            await _roles.AssignRoleToUser(userId, roleId, ct);
            return NoContent();
        }

        [HttpDelete("~/api/users/{userId:int}/roles/{roleId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveRoleFromUser(int userId, int roleId, CancellationToken ct)
        {
            await _roles.RemoveRoleFromUser(userId, roleId, ct);
            return NoContent();
        }



                // POST: api/users
        [HttpPost]
        //[Authorize(Policy = "UserManage")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(RoleCoreDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<RoleCoreDTO>> Create([FromBody] RoleCoreDTO dto, CancellationToken ct)
        {
            var newId = await _roles.Create(dto, ct);
    
            // Return the created resource so the client gets the real stored values
            var created = await _roles.GetById(newId, ct);
            return CreatedAtRoute(nameof(GetById)  , new { id = newId }, created);
        }
    



        // GET: api/roles/5
        [HttpGet("{id:int}", Name = "GetRoleById")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(RoleCoreDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoleCoreDTO>> GetById(int id, CancellationToken ct)
        {
            var role = await _roles.GetById(id, ct);
            return role is null ? NotFound() : Ok(role);
        }


        
    }

}