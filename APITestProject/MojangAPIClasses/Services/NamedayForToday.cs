using MojangAPIClasses.DataHandling;
using MojangAPIClasses.HTTPManager;
using NameDaysAPIFramework.DataHandling;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDaysAPIFramework.Services;

public class NamedayForToday
{
    #region Properties
    public CallManager CallManager { get; set; }
    public DTO<NamedayResponse> NamedayTodayDTO { get; set; }
    public string Response { get; set; }
    public JObject? JsonResponse { get; set; }
    #endregion

    public NamedayForToday()
    {
        CallManager = new CallManager();
        NamedayTodayDTO = new DTO<NamedayResponse>();
    }

    public async Task MakeRequest(Dictionary<string, string> parameters, Method method)
    {
        Response = await CallManager.MakeRequest("today", parameters, method);
        JsonResponse = JObject.Parse(Response);
        NamedayTodayDTO.DeserialiseResponse(Response);
    }

    public async Task MakeRequest(Method method)
    {
        Response = await CallManager.MakeRequest("today", new Dictionary<string, string>(), method);
        JsonResponse = JObject.Parse(Response);
        NamedayTodayDTO.DeserialiseResponse(Response);
    }

    public int GetStatusCode()
    {
        return (int)CallManager.Response.StatusCode;
    }

    public string GetHeader(string headerName)
    {
        return CallManager.Response.Headers.Where(x => x.Name.ToString() == headerName).Select(x => x.Value).ToString();
    }
}
