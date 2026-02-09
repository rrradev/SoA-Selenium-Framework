
using RestSharp;
using SeleniumFramework.ApiTests.Models.Dtos;

namespace SeleniumFramework.ApiTests.Apis;

public class UsersApi
{
    private readonly RestClient _client;
    private readonly string _uri;

    public UsersApi(RestClient restClient)
    {
        _client = restClient;
        _uri = "/users";
    }

    public RestResponse<UserDto> GetUserById(int id)
    {
        var request = new RestRequest($"{_uri}/{id}", Method.Get);
        return _client.Execute<UserDto>(request);
    }

    public RestResponse<UserDto> CreateUser(UserDto expectedUser)
    {
        var request = new RestRequest(_uri, Method.Post);
        request.AddJsonBody(expectedUser);
        
        return _client.Execute<UserDto>(request);
    }
}