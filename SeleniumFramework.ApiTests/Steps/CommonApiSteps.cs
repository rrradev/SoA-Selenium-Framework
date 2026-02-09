using FluentAssertions;
using NUnit.Framework;
using Reqnroll;

namespace SeleniumFramework.ApiTests.Steps;

[Binding]
public class CommonApiSteps
{
    private readonly ScenarioContext _scenarioContext;

    public CommonApiSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Then("the response status code should be {int}")]
    public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        var statusCode = _scenarioContext.Get<int>("StatusCode");

        Assert.That(statusCode, Is.EqualTo(expectedStatusCode));
    }

    [Then("the response should contain the following error message {string}")]
    public void ThenTheResponseShouldContainTheFollowingErrorMessage(string errorMessage)
    {
        var response = _scenarioContext.Get<string>("RawResponse");
        response.Should().Contain(errorMessage);
    }
}