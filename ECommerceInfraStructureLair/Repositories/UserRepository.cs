


using Microsoft.Data.SqlClient;          
using ECommerceDomainLair;
using ECommerceUseCaseLair;
using System.Data;
using System.Security.Cryptography.Pkcs;

namespace ECommerceInfraStructureLair
{
    public sealed class UserRepository : IUserRepository
    {

        private readonly IDbConnectionFactory _factory;

        public UserRepository(IDbConnectionFactory factory) => _factory = factory;




        private const string SelectColumns =
            "UserID, UserName, Email, PasswordHash, IsActive, CreatedAt";

        public async Task<IReadOnlyList<UserDomain>> GetAllAsync(CancellationToken ct = default)
        {
            const string sql = $"SELECT {SelectColumns} FROM dbo.Users ORDER BY UserID;";

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync(ct);

            var users = new List<UserDomain>();
            while (await reader.ReadAsync(ct))
                users.Add(Map(reader));

            return users;
        }





        public async Task<UserDomain?> GetByIdAsync(int userId, CancellationToken ct = default)
        {
            const string sql = $"SELECT {SelectColumns} FROM dbo.Users WHERE UserID = @UserID;";

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;

            await using var reader = await cmd.ExecuteReaderAsync(
                CommandBehavior.SingleRow, ct);

            return await reader.ReadAsync(ct) ? Map(reader) : null;
        }





        public async Task<UserDomain?> GetByNameAsync(string userName, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(userName)) return null;

            const string sql = $"SELECT {SelectColumns} FROM dbo.Users WHERE UserName = @UserName;";

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName.Trim();

            await using var reader = await cmd.ExecuteReaderAsync(
                CommandBehavior.SingleRow, ct);

            return await reader.ReadAsync(ct) ? Map(reader) : null;
        }




        public async Task<int> CreateAsync(UserDomain user, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(user);

            const string sql = """
                INSERT INTO dbo.Users (UserName, Email, PasswordHash, IsActive, CreatedAt)
                OUTPUT INSERTED.UserID
                VALUES (@UserName, @Email, @PasswordHash, @IsActive, @CreatedAt);
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            BindWritableColumns(cmd, user);
            cmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime2).Value = DateTime.UtcNow;

            var id = await cmd.ExecuteScalarAsync(ct);
            return Convert.ToInt32(id);
        }





        public async Task<bool> UpdateAsync(UserDomain user, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(user);

            const string sql = """
                UPDATE dbo.Users
                SET UserName = @UserName,
                    Email = @Email,
                    PasswordHash = @PasswordHash,
                    IsActive = @IsActive
                WHERE UserID = @UserID;
                """;

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            BindWritableColumns(cmd, user);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = user.UserID;


            try
            {
                // existing code
                var rows = await cmd.ExecuteNonQueryAsync(ct);
                Console.WriteLine($"Rows affected: {rows}");
                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        



        public async Task<bool> DeleteAsync(int userId, CancellationToken ct = default)
        {
            const string sql = "DELETE FROM dbo.Users WHERE UserID = @UserID;";

            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;

            //return await cmd.ExecuteNonQueryAsync(ct) > 0;


            try
            {
                // existing code
                var rows = await cmd.ExecuteNonQueryAsync(ct);
                Console.WriteLine($"Rows affected: {rows}");
                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }




        public async Task<bool> ExistsByNameAsync(string userName, CancellationToken ct = default)
        {
            const string sql = "SELECT 1 FROM dbo.Users WHERE UserName = @UserName;";
        
            await using var conn = (SqlConnection)await _factory.OpenAsync(ct);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;
        
            return await cmd.ExecuteScalarAsync(ct) is not null;
        }





        private static void BindWritableColumns(SqlCommand cmd, UserDomain user)
        {
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 256).Value = user.UserName;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 256).Value =
                (object?)user.Email ?? DBNull.Value;
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 256).Value = user.PasswordHash;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = user.IsActive;
        }




        private static UserDomain Map(SqlDataReader r)
        {
            var emailOrd = r.GetOrdinal("Email");
            return new UserDomain
            {
                UserID = r.GetInt32(r.GetOrdinal("UserID")),
                UserName = r.GetString(r.GetOrdinal("UserName")),
                Email = r.IsDBNull(emailOrd) ? null : r.GetString(emailOrd),
                PasswordHash = r.GetString(r.GetOrdinal("PasswordHash")),
                IsActive = r.GetBoolean(r.GetOrdinal("IsActive")),
                CreatedAt = r.GetDateTime(r.GetOrdinal("CreatedAt"))
            };
        }

        
    }
}