using System.Text.Json.Serialization;

namespace PveSharp.Http.Deserialization;

public class PveResponse<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; }
}