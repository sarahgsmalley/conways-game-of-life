using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GameOfLife
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CellState
    {
        Dead,
        Alive
    }
}