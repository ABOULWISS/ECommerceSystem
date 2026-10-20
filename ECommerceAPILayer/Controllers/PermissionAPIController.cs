


         
using ECommerceContractLair;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ECommerceUseCaseLair;


namespace ECommerceAPILayer
{





    [ApiController]
    [Route("api/permissions")]
    [EnableCors("UseCors")]
    //[Authorize]
    public sealed class PermissionController : ControllerBase
    {
        private readonly IPermissionUseCaseFacade _permissions;
    
        public PermissionController(IPermissionUseCaseFacade permissions)
            => _permissions = permissions ?? throw new ArgumentNullException(nameof(permissions));
    
        // GET: api/permissions/by-name/Orders.Read
        [HttpGet("by-name/{permissionName}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PermissionCoreDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermissionCoreDTO>> GetByName(string permissionName, CancellationToken ct)
        {
            var permission = await _permissions.GetPermissionByName(permissionName, ct);
            return permission is null ? NotFound() : Ok(permission);
        }
    
        // GET: api/users/5/permissions
        [HttpGet("~/api/users/{userId:int}/permissions")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IReadOnlyList<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<string>>> GetUserPermissions(int userId, CancellationToken ct)
            => Ok(await _permissions.GetUserPermissions(userId, ct));
    
        // GET: api/roles/2/permissions
        [HttpGet("~/api/roles/{roleId:int}/permissions")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IReadOnlyList<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<string>>> GetRolePermissions(int roleId, CancellationToken ct)
            => Ok(await _permissions.GetRolePermissions(roleId, ct));
    
        // PUT: api/roles/2/permissions/7
        [HttpPut("~/api/roles/{roleId:int}/permissions/{permissionId:int}")]
        //[Authorize(Policy = "PermissionManage")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AssignPermissionToRole(int roleId, int permissionId, CancellationToken ct)
        {
            await _permissions.AssignPermissionToRole(roleId, permissionId, ct);
            return NoContent();
        }

        [HttpDelete("~/api/roles/{roleId:int}/permissions/{permissionId:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemovePermissionFromRole(int roleId, int permissionId, CancellationToken ct)
        {
            await _permissions.RemovePermissionFromRole(roleId, permissionId, ct);
            return NoContent();
        }

        [HttpPut("~/api/users/{userId:int}/permissions/{permissionId:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AssignPermissionToUser(int userId, int permissionId, CancellationToken ct)
        {
            await _permissions.AssignPermissionToUser(userId, permissionId, ct);
            return NoContent();
        }

        [HttpDelete("~/api/users/{userId:int}/permissions/{permissionId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemovePermissionFromUser(int userId, int permissionId, CancellationToken ct)
        {
            await _permissions.RemovePermissionFromUser(userId, permissionId, ct);
            return NoContent();
        }




        [HttpPost]
        //[Authorize(Policy = "UserManage")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PermissionCoreDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<PermissionCoreDTO>> Create([FromBody] PermissionCoreDTO dto, CancellationToken ct)
        {
            var newId = await _permissions.Create(dto, ct);
    
            // Return the created resource so the client gets the real stored values
            var created = await _permissions.GetById(newId, ct);
            return CreatedAtRoute(nameof(GetById)  , new { id = newId }, created);
        }
    



        // GET: api/roles/5
        [HttpGet("{id:int}", Name = "GetPermissionById")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PermissionCoreDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermissionCoreDTO>> GetById(int id, CancellationToken ct)
        {
            var pr = await _permissions.GetById(id, ct);
            return pr is null ? NotFound() : Ok(pr);
        }


    }

}