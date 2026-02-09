namespace SeleniumFramework.DatabaseOperations.Queries
{
    public static class UserQueries
    {
        public static string DeleteUserByEmail(string email)
        {
            return $@"
                DELETE FROM users
                WHERE email = '{email}';
            ";
        }

        public static string GetUserIdByEmail(string email)
        {
            return $@"
                SELECT 1 FROM users
                WHERE email = '{email}';
            ";
        }
    }
}
