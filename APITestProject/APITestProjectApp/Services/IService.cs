using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDaysAPIFramework.Services;

public interface IService
{
    #region Properties
    public CallManager CallManager { get; set; }
    public DTO<NamedayResponse> NamedayTodayDTO { get; set; }
    public string Response { get; set; }
    public JObject? JsonResponse { get; set; }
    #endregion

    public Task MakeRequest(Dictionary<string, string> parameters, Method method);
    public Task MakeRequest(Method method);
    public int GetStatusCode();
    public string GetHeader(string headerName);
}
