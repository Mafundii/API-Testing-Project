using APITestProjectApp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPManager;

public class CallManager
{
    private readonly RestClient? _client;
    public RestResponse? Response { get; set; }

    public CallManager()
    {
        _client = new RestClient(ConfigReader.BaseURL);
    }

    public CallManager(string url)
    {
        _client = new RestClient(url);
    }

    public async Task<string> MakeRequest(string resource, Dictionary<string, string> parameters, Method method)
    {
        var request = new RestRequest();
        request.Method = method;
        request.AddHeader("Content-Type", "application/json");
        request.Resource = resource;
        request.AddBody(parameters);

        Response = await _client.ExecuteAsync(request);
        return Response.Content;
    }
}
