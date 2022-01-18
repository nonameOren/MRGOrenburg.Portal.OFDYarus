using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MRG.OFDYarus.Application.Responses
{
    public class KKTResponse
    {
        /// <summary>
        /// Массив ККТ(номеров ФН)
        /// </summary>
        [JsonPropertyName("kkt")]        
        public IDictionary<string, KKT> Kkt { get; set; }
        /// <summary>
        /// Количество касс
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class KKTv2Response
    {
        /// <summary>
        /// Массив ККТ(номеров ФН)
        /// </summary>
        [JsonPropertyName("kkt")]
        public IDictionary<string, IEnumerable<KKT>> Kkt { get; set; }
        /// <summary>
        /// Количество касс
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class KKT
    {
        /// <summary>
        /// Адрес ККТ
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
        /// <summary>
        /// Время последнего успешно полученного документа
        /// </summary>
        [JsonPropertyName("last")]
        public string Last { get; set; }
        ///// <summary>
        ///// Регистрационный номер ККТ
        ///// </summary>
        [JsonPropertyName("kktregid")]
        public string KktRegid { get; set; }
        ///// <summary>
        ///// Сумма переданных данных в ФНС
        ///// </summary>
        [JsonPropertyName("turnover")]
        public string Turnover { get; set; }
        ///// <summary>
        ///// Количество операций
        ///// </summary>
        [JsonPropertyName("receiptCount")]
        public string ReceiptCount { get; set; }
    }
}
