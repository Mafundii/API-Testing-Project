# Nameday API Testing Framework

### Created by:

Dan Summerside (Scrum Master)

Kai Chan

Maks Hadys

### Introduction

This is a Sparta Global Academy project which consists of a testing framework for a Nameday API.

##### What is a nameday?

A *name day* (also known as feast day) is a tradition in many countries in Europe of celebrating a day based on an individual's given name.

### 1. API Documentation

https://nameday.abalin.net/docs/

### 2. Service Classes

This testing framework requires several service classes outlined below. The classes utilise the "IServices" interface:

```c#
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
```

The classes make use of a number of sync and async methods to communicate with the API and receive relevant information according to the input provided.

### 3. Example of Service Class

This class corresponds to the request for the namedays for the current day.

```c#
public class NamedayForTodayService
{
    #region Properties
    public CallManager CallManager { get; set; }
    public DTO<NamedayResponse> NamedayTodayDTO { get; set; }
    public string Response { get; set; }
    public JObject? JsonResponse { get; set; }
    #endregion

    public NamedayForTodayService()
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
```



### 3. Class Diagram

![class diagram](https://user-images.githubusercontent.com/108397810/183383315-10be3ac2-8a8f-404f-9751-3101bcdafd35.PNG)

### 4. Test Coverage

The testing framework covers POST and GET requests for the following scenarios:

- Searching for nameday by name
- Searching for nameday by date
- Namedays for today's date 
- Namedays for tomorrow's date
- Namedays for yesterday's date

### 5. Defects Found

- Not possible to check for a specific name in all countries, only one country at a time
- GetDate and PostDate with non-integer day return Error 422 with a relevant error message, but those with non-integer month return Error 500 without a relevant error message
- Get and recieve speed is slow, tests take a long time to run (to solve, await data then run the tests)



