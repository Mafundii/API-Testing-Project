using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojangAPIClasses.DataHandling;

public class DTO<ResponseType> where ResponseType : IResponse, new()
{
    public ResponseType? Response { get; set; }
    internal void DeserialiseResponse(string response)
    {
        Response = JsonConvert.DeserializeObject<ResponseType>(response);
    }
}
