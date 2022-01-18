using System.Text.Json.Serialization;

namespace MRG.OFDYarus.Application.Requests
{
    public class TPNumberRequest
    {
        [JsonPropertyName("TP")]
        public int TP { get; }
        public TPNumberRequest(int tP)
        {
            TP = tP;
        }
    }
}
