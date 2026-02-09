namespace SeleniumFramework.Models.Factories
{
    public interface IUserFactory
    {
        UserModel CreateDefault();
        UserModel Create(string email, string password);
    }

    public class UserFactory : IUserFactory
    {
        public UserModel CreateDefault()
        {
            var user = new UserModel
            {
                FirstName = "John",
                Surname = "Doe",
                Email = $"john.doe{Guid.NewGuid()}@example.com",
                Password = "SecureP@ssw0rd",
                Country = "USA",
                City = "New York"
            };

            return user;
        }

        public UserModel Create(string email, string password)
        {
            var user = CreateDefault();
            user.Email = email;
            user.Password = password;

            return user;
        }
    }
}
