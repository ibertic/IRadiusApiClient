//Using to IRadius Api CLient Lib
using Ibertic.Iradius.Api.Client;

public class ApiManager
{
    private const string apiurl = "http://api.iradius.es";

    public string Token { get; set; }
    public ApiClient ApiClient { get; set; }

  public ApiManager( string token)
    {
        this.Token = token;
        ApiClient = new ApiClient(apiurl, token);
    }
}