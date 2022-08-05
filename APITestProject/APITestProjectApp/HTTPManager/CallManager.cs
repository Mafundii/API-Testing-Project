using NameDaysAPIFramework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojangAPIClasses.HTTPManager;

public class CallManager
{
    private readonly RestClient? _client;
    public RestResponse? Response { get; set; }

    public CallManager()
    {
        _client = new RestClient(ConfigReader.BaseURL);
    }

    public async Task<string> MakeRequest(string resource, Dictionary<string, string> parameters, Method method)
    {
        var request = new RestRequest();
        request.Method = method;
        request.AddHeader("Content-Type", "application/json");
        request.Resource = resource;
        foreach (var p in parameters)
            request.AddParameter(p.Key, p.Value);

        Response = await _client.ExecuteAsync(request);
        return Response.Content;
    }
}
