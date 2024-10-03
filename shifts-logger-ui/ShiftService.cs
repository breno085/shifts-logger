using RestSharp;
using Newtonsoft.Json;
using System;
using shifts_logger_ui.Models;

namespace shifts_logger_ui;

public class ShiftService
{
    public void GetWorkerLog(int workerId)
    {
        var client = new RestClient("http://localhost:5123");
        var request = new RestRequest($"api/ShiftLogger/{workerId}");

        // .Result in the end Force asynchronous execution to run synchronously
        var response = client.ExecuteAsync(request).Result;

        if (response.IsSuccessful)
        {
            var worker = JsonConvert.DeserializeObject<Worker>(response.Content);
            Console.WriteLine(
                $"Worker ID: {worker.Id}\nWorker Name: {worker.Name}\nStart: {worker.Start}\nEnd: {worker.End}\nDuration: {worker.Duration}");
        }
        else
        {
            Console.WriteLine($"Failed to get worker. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
        }
    }

    public void GetWorkersLogs()
    {
        var client = new RestClient("http://localhost:5123");
        var request = new RestRequest($"api/ShiftLogger/GetAll");

        // .Result in the end Force asynchronous execution to run synchronously
        var response = client.ExecuteAsync(request).Result;

        if (response.IsSuccessful)
        {
            var workers = JsonConvert.DeserializeObject<List<Worker>>(response.Content);

            foreach (var worker in workers)
            {
                Console.WriteLine(
                $"Worker ID: {worker.Id}\nWorker Name: {worker.Name}\nStart: {worker.Start}\nEnd: {worker.End}\nDuration: {worker.Duration}\n\n");
            }
        }

        else
        {
            Console.WriteLine($"Failed to get worker. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
        }
    }

    public void CreateWorkerLog(Worker newWorkerLog)
    {
        var client = new RestClient("http://localhost:5123");
        var request = new RestRequest("api/ShiftLogger", Method.Get);

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

    public void UpdateWorkerLog(int workerId, Worker updatedWorkerLog)
    {
        var client = new RestClient("http://localhost:5123");
        var request = new RestRequest($"api/ShiftLogger/{workerId}", Method.Put);

        var jsonBody = JsonConvert.SerializeObject(updatedWorkerLog);
        request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

        // Force asynchronous execution to run synchronously with .Result
        var response = client.ExecuteAsync(request).Result;

        if (response.IsSuccessful)
        {
            Console.WriteLine("Worker log updated successfully.");
        }
        else
        {
            Console.WriteLine($"Failed to update worker log. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
        }
    }

    public void DeleteWorkerLog(int workerId)
    {
        var client = new RestClient("http://localhost:5123");
        var request = new RestRequest($"api/ShiftLogger/{workerId}", Method.Delete);

        // Force asynchronous execution to run synchronously with .Result
        var response = client.ExecuteAsync(request).Result;

        if (response.IsSuccessful)
        {
            Console.WriteLine("Worker log deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Failed to delete worker log. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
        }
    }





}