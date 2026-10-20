

using System.Security.Claims;
using ECommerceContractLair;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ECommerceUseCaseLair;


namespace ECommerceAPILayer
{          




    [ApiController]
    [Route("api/users")]
    [EnableCors("UseCors")]
    [Authorize]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserUseCaseFacade _users;
    
        public UserController(IUserUseCaseFacade users)
            => _users = users ?? throw new ArgumentNullException(nameof(users));
    
        // GET: api/users
        [HttpGet]
        //[Authorize(Policy = "UserManage")]
        [ProducesResponseType(typeof(IReadOnlyList<UserCoreDTO>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<UserCoreDTO>>> GetAll(CancellationToken ct)
            => Ok(await _users.GetAll(ct));
    





        // GET: api/users/5
        [HttpGet("{id:int}", Name = nameof(GetById))]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserCoreDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserCoreDTO>> GetById(int id, CancellationToken ct)
        {
           // if (!IsSelfOrAdmin(id)) return Forbid();
    
            var user = await _users.GetById(id, ct);
            return user is null ? NotFound() : Ok(user);
        }
    





        // GET: api/users/by-name/john
        [HttpGet("by-name/{userName}")]
        //[Authorize(Policy = "UserManage")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserCoreDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserCoreDTO>> GetByName(string userName, CancellationToken ct)
        {
            var user = await _users.GetByName(userName, ct);
            return user is null ? NotFound() : Ok(user);
        }





    
        // HEAD: api/users/by-name/john   (200 = exists, 404 = free)
        [HttpHead("by-name/{userName}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExistsByName(string userName, CancellationToken ct)
            => await _users.ExistsByName(userName, ct) ? Ok() : NotFound();
    






        // POST: api/users
        [HttpPost]
        //[Authorize(Policy = "UserManage")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserCoreDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserCoreDTO>> Create([FromBody] UserCoreDTO dto, CancellationToken ct)
        {
            var newId = await _users.Create(dto, ct);
    
            // Return the created resource so the client gets the real stored values
            var created = await _users.GetById(newId, ct);
            return CreatedAtRoute(nameof(GetById), new { id = newId }, created);
        }
    






        // PUT: api/users/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [AllowAnonymous]
        public async Task<IActionResult> Update(int id, [FromBody] UserCoreDTO dto, CancellationToken ct)
        {
             
             var updated = await _users.Update(id , dto, ct);   // whatever your read method is called
          
             return Ok(updated);
        }
    

        // DELETE: api/users/5
        [HttpDelete("{id:int}")]
       // [Authorize(Policy = "UserManage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            if (!await _users.Delete( id,ct)) return NotFound();
            return Ok();
        }

        private bool IsSelfOrAdmin(int userId)
            => User.FindFirst(ClaimTypes.NameIdentifier)?.Value == userId.ToString()
               || User.IsInRole("Admin");



    }
}
