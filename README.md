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

### 3. Class Diagram

![image-20220807233539631](C:\Users\maksh\AppData\Roaming\Typora\typora-user-images\image-20220807233539631.png)

### 4. Test Coverage

The testing framework covers POST and GET requests for the following scenarios:

- Searching for nameday by name
- Searching for nameday by date
- Namedays for today's date 
- Namedays for tomorrow's date
- Namedays for yesterday's date

### 5. Defects Found

