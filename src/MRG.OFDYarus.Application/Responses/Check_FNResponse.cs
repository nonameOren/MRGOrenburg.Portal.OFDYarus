using System.Text.Json.Serialization;

namespace MRG.OFDYarus.Application.Responses
{
    public class Check_FNResponse
    {
        /// <summary>
        /// Код запроса
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }
        /// <summary>
        /// Блок информации о ККТ
        /// </summary>
        [JsonPropertyName("kkt")]
        public Kkt Kkt { get; set; }
        /// <summary>
        /// Статус обработки последнего фискального документа
        /// </summary>
        [JsonPropertyName("desc")]
        public string Desc { get; set; }
    }

    public class Kkt
    {
        /// <summary>
        /// Признак переполнения памяти ФН (True/ False) Архив памяти заполнен на 90 процентов
        /// </summary>
        [JsonPropertyName("fiscalDriveMemoryExceededSign")]
        public bool FiscalDriveMemoryExceededSign { get; set; }
        /// <summary>
        /// Дата последнего фискального документа (в Str) 
        /// </summary>
        [JsonPropertyName("last_date_str")]
        public string Last_date_str { get; set; }
        /// <summary>
        /// Номер фискального накопителя (ФН)
        /// </summary>
        [JsonPropertyName("fiscalDriveNumber")]
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Дата последнего фискального документа (в Unix Time, в секундах)
        /// </summary>
        [JsonPropertyName("last_date")]
        public int Last_date { get; set; }
        /// <summary>
        /// Информация о разрешении на прием документов (True/False)
        /// </summary>
        [JsonPropertyName("activated")]
        public bool Activated { get; set; }
        /// <summary>
        /// Признак исчерпания ресурса ФН ( значения True/False) до окончания срока 30 дней
        /// </summary>
        [JsonPropertyName("fiscalDriveExhaustionSign")]
        public bool FiscalDriveExhaustionSign { get; set; }
        /// <summary>
        /// Признак необходимости срочной замены ФН (True/ False) до окончания срока 3 дня
        /// </summary>
        [JsonPropertyName("fiscalDriveReplaceRequiredSign")]
        public bool FiscalDriveReplaceRequiredSign { get; set; }
    }


}
