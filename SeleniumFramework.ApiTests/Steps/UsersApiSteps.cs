using FluentAssertions;
using NUnit.Framework;
using Reqnroll;
using SeleniumFramework.ApiTests.Apis;
using SeleniumFramework.ApiTests.Models.Dtos;
using SeleniumFramework.ApiTests.Utils.Types;

namespace SeleniumFramework.ApiTests.Steps;

[Binding]
public class UsersApiSteps
{
    private readonly UsersApi _usersApi;
    private readonly ScenarioContext _scenarioContext;

    public UsersApiSteps(UsersApi usersApi, ScenarioContext scenarioContext)
    {
        _usersApi = usersApi;
        _scenarioContext = scenarioContext;
    }


    [Given("I make a get request to users endpoint with id {int}")]
    public void GivenIMakeAGetRequestToUsersEndpointWithId(int id)
    {
        var response = _usersApi.GetUserById(id);
        _scenarioContext["StatusCode"] = (int)response.StatusCode;
        if (response.IsSuccessful)
        {
            _scenarioContext["UsersResponse"] = response.Data;
        }

        _scenarioContext["RawResponse"] = response.Content;
    }

    [Then("users response should contain the following data:")]
    public void ThenUsersResponseShouldContainTheFollowingData(Table table)
    {
        var expectedUser = table.CreateInstance<UserDto>();
        expectedUser.Password = StringUtils.Sha256(expectedUser.Password);

        var usersResponse = _scenarioContext.Get<UserDto>("UsersResponse");

        Assert.That(usersResponse.Id, Is.EqualTo(expectedUser.Id));
        Assert.That(usersResponse.FirstName, Is.EqualTo(expectedUser.FirstName));
    }

    [Given("I make a post request to users endpoint with the following data:")]
    public void GivenIMakeAPostRequestToUsersEndpointWithTheFollowingData(Reqnroll.Table table)
    {
        var timestamp = DateTime.Now.ToFileTime();
        var expectedUser = table.CreateInstance<UserDto>();
        expectedUser.Email = expectedUser.Email.Replace("@", $"{timestamp}@");
        var createUserResponse = _usersApi.CreateUser(expectedUser);
        _scenarioContext["StatusCode"] = (int)createUserResponse.StatusCode;
        _scenarioContext["UsersResponse"] = createUserResponse.Data;
    }

    [Then("create users response should contain the following data:")]
    public void ThenCreateUsersResponseShouldContainTheFollowingData(Reqnroll.Table table)
    {
        var expectedUser = table.CreateInstance<UserDto>();
        var actualUser = _scenarioContext.Get<UserDto>("UsersResponse");

        actualUser.Should().BeEquivalentTo(
            expectedUser,
            options => options
                .Excluding(u => u.Id)
                .Excluding(u => u.Password)
                .Excluding(u => u.Email)
        );
    }
}