using RestSharp;
using Newtonsoft.Json;
using System;
using shifts_logger_ui.Models;

namespace shifts_logger_ui;

public class ShiftService
{
    public void GetWorkerLog(int workerId)
    {
        var client = new RestClient("https://yourapiurl");
        var request = new RestRequest($"api/workers/{workerId}");

        // .Result in the end Force asynchronous execution to run synchronously
        var response = client.ExecuteAsync(request).Result;

        if (response.IsSuccessful)
        {
            var worker = JsonConvert.DeserializeObject<Worker>(response.Content);
            Console.WriteLine($"Worker Name: {worker.Name}, Worker ID: {worker.Id}");
        }
        else
        {
            Console.WriteLine($"Failed to get worker. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
        }

    }

    public void CreateWorkerLog(Worker newWorkerLog)
    {
        var client = new RestClient("https://yourapiurl");
        var request = new RestRequest("api/workers", Method.Post);

        var jsonBody = JsonConvert.SerializeObject(newWorkerLog);
        request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

        // Force asynchronous execution to run synchronously
        var response = client.ExecuteAsync(request).GetAwaiter().GetResult();

        if (response.IsSuccessful)
        {
            Console.WriteLine("Worker created successfully.");
        }
        else
        {
            Console.WriteLine($"Failed to create worker shift. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
        }

    }
}