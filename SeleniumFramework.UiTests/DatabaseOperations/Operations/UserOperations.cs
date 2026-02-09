using SeleniumFramework.DatabaseOperations.Queries;
using System.Data;

namespace SeleniumFramework.DatabaseOperations.Operations
{
    public class UserOperations : IDisposable
    {
        private readonly IDbConnection _connection;

        public UserOperations(IDbConnection connection)
        {
            this._connection = connection;
            this._connection.Open();
        }

        public void DeleteUserWithEmail(string email)
        {
            var command = this._connection.CreateCommand();
            command.CommandText = UserQueries.DeleteUserByEmail(email);
            command.ExecuteNonQuery();
        }

        public bool CheckIfUserExistsByEmail(string email)
        {
            var command = this._connection.CreateCommand();
            command.CommandText = UserQueries.GetUserIdByEmail(email);
            var result = command.ExecuteScalar();

            return result != null && Convert.ToInt32(result) == 1;
        }

        public void Dispose()
        {
            this._connection?.Close();
            this._connection?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
