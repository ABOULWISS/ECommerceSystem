using Microsoft.Data.SqlClient;
using ECommerceDomainLair;
using ECommerceUseCaseLair;
using System.Data;

namespace ECommerceInfraStructureLair
{
    public sealed class PermissionRepository : IPermissionsRepository
    {
        private readonly IDbConnectionFactory _factory;

        public PermissionRepository(IDbConnectionFactory factory) => _factory = factory;

        private const string SelectColumns =
            "PermissionID, PermissionName, PermissionDescription, CreatedAt";

        public async Task AssignPermissionToRoleAsync(
            int roleId, int permissionId, CancellationToken ct = default)
        {
            const string sql = """
                IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE RoleID = @RoleID)
                    THROW 50001, 'Role not found.', 1;

                IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionID = @PermissionID)
                    THROW 50002, 'Permission not found.', 1;

                IF NOT EXISTS (SELECT 1
                               FROM dbo.RolePermissions WITH (UPDLOCK, HOLDLOCK)
                               WHERE RoleID = @RoleID AND PermissionID = @PermissionID)
                BEGIN
                    INSERT INTO dbo.RolePermissions (RoleID, PermissionID)
                    VALUES (@RoleID, @PermissionID);
                END
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleId;
            cmd.Parameters.Add("@PermissionID", SqlDbType.Int).Value = permissionId;

            try
            {
                await cmd.ExecuteNonQueryAsync(ct);
            }
            catch (SqlException ex) when (ex.Number == 50001)
            {
                throw new KeyNotFoundException("Role not found.");
            }
            catch (SqlException ex) when (ex.Number == 50002)
            {
                throw new KeyNotFoundException("Permission not found.");
            }
        }

        public async Task RemovePermissionFromRoleAsync(
            int roleId, int permissionId, CancellationToken ct = default)
        {
            const string sql = """
                DELETE FROM dbo.RolePermissions
                WHERE RoleID = @RoleID AND PermissionID = @PermissionID;
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleId;
            cmd.Parameters.Add("@PermissionID", SqlDbType.Int).Value = permissionId;

            var rows = await cmd.ExecuteNonQueryAsync(ct);
            if (rows == 0)
                throw new KeyNotFoundException("This permission is not assigned to the role.");
        }

        public async Task AssignPermissionToUserAsync(
            int userId, int permissionId, CancellationToken ct = default)
        {
            const string sql = """
                IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserID = @UserID)
                    THROW 50003, 'User not found.', 1;

                IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionID = @PermissionID)
                    THROW 50002, 'Permission not found.', 1;

                IF NOT EXISTS (SELECT 1
                               FROM dbo.userPermission WITH (UPDLOCK, HOLDLOCK)
                               WHERE UserID = @UserID AND PermissionID = @PermissionID)
                BEGIN
                    INSERT INTO dbo.userPermission (UserID, PermissionID, AssignedAt)
                    VALUES (@UserID, @PermissionID, @AssignedAt);
                END
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
            cmd.Parameters.Add("@PermissionID", SqlDbType.Int).Value = permissionId;
            cmd.Parameters.Add("@AssignedAt", SqlDbType.DateTime2).Value = DateTime.UtcNow;

            try
            {
                await cmd.ExecuteNonQueryAsync(ct);
            }
            catch (SqlException ex) when (ex.Number == 50003)
            {
                throw new KeyNotFoundException("User not found.");
            }
            catch (SqlException ex) when (ex.Number == 50002)
            {
                throw new KeyNotFoundException("Permission not found.");
            }
        }

        public async Task RemovePermissionFromUserAsync(
            int userId, int permissionId, CancellationToken ct = default)
        {
            const string sql = """
                DELETE FROM dbo.userPermission
                WHERE UserID = @UserID AND PermissionID = @PermissionID;
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
            cmd.Parameters.Add("@PermissionID", SqlDbType.Int).Value = permissionId;

            var rows = await cmd.ExecuteNonQueryAsync(ct);
            if (rows == 0)
                throw new KeyNotFoundException("This permission is not assigned to the user.");
        }

        public async Task<IReadOnlyList<string>> GetPermissionsForUserAsync(
            int userId, CancellationToken ct = default)
        {
            const string sql = """
                SELECT DISTINCT p.PermissionName
                FROM dbo.Permissions p
                WHERE p.PermissionID IN
                (
                    SELECT rp.PermissionID
                    FROM dbo.UserRoles ur
                    JOIN dbo.RolePermissions rp ON rp.RoleID = ur.RoleID
                    WHERE ur.UserID = @UserID

                    UNION

                    SELECT up.PermissionID
                    FROM dbo.userPermission up
                    WHERE up.UserID = @UserID
                );
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;

            await using var reader = await cmd.ExecuteReaderAsync(ct);

            var permissions = new List<string>();
            while (await reader.ReadAsync(ct))
                permissions.Add(reader.GetString(0));

            return permissions;
        }

        public async Task<IReadOnlyList<string>> GetPermissionsForRoleAsync(
            int roleId, CancellationToken ct = default)
        {
            const string sql = """
                SELECT DISTINCT p.PermissionName
                FROM dbo.RolePermissions rp
                JOIN dbo.Permissions p ON p.PermissionID = rp.PermissionID
                WHERE rp.RoleID = @RoleID;
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleId;

            await using var reader = await cmd.ExecuteReaderAsync(ct);

            var permissions = new List<string>();
            while (await reader.ReadAsync(ct))
                permissions.Add(reader.GetString(0));

            return permissions;
        }

        public async Task<PermissionDomain?> GetPermissionByNameAsync(
            string permissionName, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(permissionName)) return null;

            const string sql = $"""
                SELECT {SelectColumns}
                FROM dbo.Permissions
                WHERE PermissionName = @PermissionName;
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@PermissionName", SqlDbType.NVarChar, 256).Value = permissionName.Trim();

            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleRow, ct);
            return await reader.ReadAsync(ct) ? Map(reader) : null;
        }

        public async Task<PermissionDomain?> GetByIdAsync(int prId, CancellationToken ct = default)
        {
            const string sql = $"SELECT {SelectColumns} FROM dbo.Permissions WHERE PermissionID = @PermissionID;";

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@PermissionID", SqlDbType.Int).Value = prId;

            await using var reader = await cmd.ExecuteReaderAsync(
                CommandBehavior.SingleRow, ct);

            return await reader.ReadAsync(ct) ? Map(reader) : null;
        }

        public async Task<int> CreateAsync(PermissionDomain pr, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(pr);

            const string sql = """
                INSERT INTO dbo.Permissions (PermissionName, PermissionDescription , CreatedAt)
                OUTPUT INSERTED.PermissionID
                VALUES (@PermissionName, @PermissionDescription, @CreatedAt);
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            BindWritableColumns(cmd, pr);
            cmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime2).Value = DateTime.UtcNow;

            var id = await cmd.ExecuteScalarAsync(ct);
            return Convert.ToInt32(id);
        }

        public async Task<bool> ExistsByNameAsync(string permissionName, CancellationToken ct = default)
        {
            const string sql = "SELECT 1 FROM dbo.Permissions WHERE PermissionName = @PermissionName;";

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@PermissionName", SqlDbType.NVarChar, 256).Value = permissionName;

            return await cmd.ExecuteScalarAsync(ct) is not null;
        }

        private static PermissionDomain Map(SqlDataReader r)
        {
            var descOrd = r.GetOrdinal("PermissionDescription");
            return new PermissionDomain
            {
                PermissionID = r.GetInt32(r.GetOrdinal("PermissionID")),
                PermissionName = r.GetString(r.GetOrdinal("PermissionName")),
                PermissionDescription = r.IsDBNull(descOrd) ? null : r.GetString(descOrd),
                CreatedAt = r.GetDateTime(r.GetOrdinal("CreatedAt"))
            };
        }

        private static void BindWritableColumns(SqlCommand cmd, PermissionDomain pr)
        {
            cmd.Parameters.Add("@PermissionName", SqlDbType.NVarChar, 256).Value = pr.PermissionName;
            cmd.Parameters.Add("@PermissionDescription", SqlDbType.NVarChar, 256).Value =
                (object?)pr.PermissionDescription ?? DBNull.Value;
        }
    }
}
