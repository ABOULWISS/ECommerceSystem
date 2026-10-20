using ECommerceDomainLair;
using ECommerceUseCaseLair;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfraStructureLair
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ECommerceDbContext _eCommerceDbContext;

        public RoleRepository(ECommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }

        public async Task AssignRoleToUserAsync(
            int userId,
            int roleId,
            CancellationToken cancellationToken = default)
        {
            bool userExists = await _eCommerceDbContext.Users
                .AnyAsync(u => u.UserID == userId, cancellationToken);
            if (!userExists)
                throw new KeyNotFoundException("User not found.");

            bool roleExists = await _eCommerceDbContext.Roles
                .AnyAsync(r => r.RoleID == roleId, cancellationToken);
            if (!roleExists)
                throw new KeyNotFoundException("Role not found.");

            bool alreadyAssigned = await _eCommerceDbContext.UserRoles
                .AnyAsync(ur => ur.UserID == userId && ur.RoleID == roleId, cancellationToken);

            if (alreadyAssigned)
                return;

            _eCommerceDbContext.UserRoles.Add(new UserRoleDomain
            {
                UserID = userId,
                RoleID = roleId,
                AssignedAt = DateTime.UtcNow
            });

            await _eCommerceDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveRoleFromUserAsync(
            int userId,
            int roleId,
            CancellationToken cancellationToken = default)
        {
            var assignment = await _eCommerceDbContext.UserRoles
                .FirstOrDefaultAsync(
                    ur => ur.UserID == userId && ur.RoleID == roleId,
                    cancellationToken);

            if (assignment is null)
                throw new KeyNotFoundException("This role is not assigned to the user.");

            _eCommerceDbContext.UserRoles.Remove(assignment);
            await _eCommerceDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<string>> GetRolesForUserAsync(
            int userId,
            CancellationToken cancellationToken = default)
        {
            return await _eCommerceDbContext.UserRoles
                .Where(ur => ur.UserID == userId)
                .Select(ur => ur.Role!.RoleName)
                .Distinct()
                .ToListAsync(cancellationToken);
        }

        public async Task<RoleDomain?> GetRoleByNameAsync(
            string roleName,
            CancellationToken cancellationToken = default)
        {
            return await _eCommerceDbContext.Roles
                .FirstOrDefaultAsync(
                    r => r.RoleName == roleName,
                    cancellationToken);
        }

        public async Task<int> CreateAsync(RoleDomain role, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(role);

            var entity = new RoleDomain
            {
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription,
                CreatedAt = DateTime.UtcNow
            };

            _eCommerceDbContext.Roles.Add(entity);
            await _eCommerceDbContext.SaveChangesAsync(ct);

            return entity.RoleID;
        }

        public async Task<RoleDomain?> GetByIdAsync(int roleId, CancellationToken ct = default)
        {
            return await _eCommerceDbContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RoleID == roleId, ct);
        }

        public async Task<bool> ExistsByNameAsync(string roleName, CancellationToken ct = default)
        {
            return await _eCommerceDbContext.Roles
                .AsNoTracking()
                .AnyAsync(r => r.RoleName == roleName, ct);
        }
    }
}
