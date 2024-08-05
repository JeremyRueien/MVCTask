using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YungChingTask.Common;

public class HttpResponse
{
    public static HttpResponse<T> Create<T> (T data) where T : class => new() { Data = data };
    public static HttpResponse<object> Create() => new()
    {
        Data = new object()
    };
}


public class HttpResponse<T> where T : class
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T Data { get; set; }
    public JsonResult ToJson()
    {
        return new JsonResult(this,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
    }
}