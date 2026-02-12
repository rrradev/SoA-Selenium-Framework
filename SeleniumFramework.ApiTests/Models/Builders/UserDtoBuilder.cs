using SeleniumFramework.ApiTests.Models.Dtos;

namespace SeleniumFramework.ApiTests.Models.Builders;

public class UserDtoBuilder
{
    private UserDto _userDto;

    public UserDtoBuilder()
    {
        _userDto = new UserDto();
    }

    public UserDtoBuilder WithDefaultValues()
    {
        _userDto.FirstName = "John";
        _userDto.SirName = "Doe";
        _userDto.Email = $"john.doe{Guid.NewGuid()}@example.com";
        _userDto.Password = "SecureP@ssw0rd";
        _userDto.Country = "USA";
        _userDto.City = "New York";
        _userDto.Title = "Mr.";
        _userDto.IsAdmin = 0;
        
        return this;
    }
    
    public UserDto Build()
    {
        return _userDto;
    }
}