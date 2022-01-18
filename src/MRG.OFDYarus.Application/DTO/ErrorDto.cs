using System.Text.Json.Serialization;

namespace MRG.OFDYarus.Application.DTO
{
    public class ErrorDto
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [JsonPropertyName("desc")]
        public string Desc { get; set; }
    }
}
