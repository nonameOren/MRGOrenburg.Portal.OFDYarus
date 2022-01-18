using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MRG.OFDYarus.Application.Responses
{
    public class TPv1Response
    {
        /// <summary>
        /// Список торговых точек
        /// </summary>
        [JsonPropertyName("trade_points")]
        public IEnumerable<TPv1Item> Trade_points { get; set; }
        /// <summary>
        /// Количество торговых точек
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class TPv2Response
    { 
        /// <summary>
        /// Список торговых точек
        /// </summary>
        [JsonPropertyName("trade_points")]
        public IEnumerable<TPv2Item> Trade_points { get; set; }
        /// <summary>
        /// Количество торговых точек
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class TPItemBase
    {
        /// <summary>
        /// Минимальный чек в торговой точке
        /// </summary>
        public string Minsum { get; set; }
        /// <summary>
        /// Адрес торговой точки
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Максимальный чек в торговой точке
        /// </summary>
        public string Maxsum { get; set; }
        /// <summary>
        /// Средний чек
        /// </summary>
        public string Avgsum { get; set; }
        /// <summary>
        /// Сумма переданных данных в ФНС
        /// </summary>
        public string Turnover { get; set; }
        /// <summary>
        /// Количество операций
        /// </summary>
        public int ReceiptCount { get; set; }
    }

    /// <summary>
    /// Торговые точки
    /// </summary>
    public class TPv1Item: TPItemBase
    {
        /// <summary>
        /// Список ФН (номеров фискального накопителя)
        /// </summary>
        public IEnumerable<string> FiscalDriverNumber { get; set; }
    }

    /// <summary>
    /// Торговые точки
    /// </summary>
    public class TPv2Item : TPItemBase
    {
        /// <summary>
        /// Список ФН (номеров фискального накопителя)
        /// </summary>
        public IEnumerable<string> FiscalDriveNumber { get; set; }
    }
}
