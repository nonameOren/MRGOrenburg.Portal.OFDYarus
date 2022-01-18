using System.Text.Json.Serialization;

namespace MRG.OFDYarus.Application.Responses
{
    public class CloseShiftReportResponse
    {
        /// <summary>
        /// дата, время
        /// </summary>
        public string dateTime { get; set; }
        /// <summary>
        /// признак переполнения памяти ФН
        /// </summary>
        public int fiscalDriveMemoryExceededSign { get; set; }
        /// <summary>
        /// признак превышения времени ожидания ответа ОФД
        /// </summary>
        public int ofdResponseTimeoutSign { get; set; }

        public int fiscalDocumentFormatVer { get; set; }
        /// <summary>
        /// код документа (всегда равен 5)
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// ИНН пользователя
        /// </summary>
        public string userInn { get; set; }
        /// <summary>
        /// регистрационный номер ККТ
        /// </summary>
        public string kktRegId { get; set; }
        /// <summary>
        /// заводской номер фискального накопителя
        /// </summary>
        public string fiscalDriveNumber { get; set; }
        /// <summary>
        /// номер смены
        /// </summary>
        public int shiftNumber { get; set; }
        /// <summary>
        /// количество чеков (БСО) за смену
        /// </summary>
        public int receiptQuantity { get; set; }
        /// <summary>
        /// кассир
        /// </summary>
        [JsonPropertyName("operator")]
        public string _operator { get; set; }
        /// <summary>
        /// признак необходимости срочной замены ФН
        /// </summary>
        public int fiscalDriveReplaceRequiredSign { get; set; }
        /// <summary>
        /// кол-во непереданных документов ФД
        /// </summary>
        public int notTransmittedDocumentsQuantity { get; set; }
        /// <summary>
        /// порядковый номер фискального документа
        /// </summary>
        public int fiscalDocumentNumber { get; set; }
        /// <summary>
        /// фискальный признак документа
        /// </summary>
        public long fiscalSign { get; set; }
        /// <summary>
        /// дата и время первого из непереданных ФД (в Unix Time, в секундах)
        /// </summary>
        public int notTransmittedDocumentsDateTime { get; set; }
        /// <summary>
        /// количество фискальных документов за смену
        /// </summary>
        public int documentsQuantity { get; set; }
        /// <summary>
        /// признак исчерпания ресурса ФН
        /// </summary>
        public int fiscalDriveExhaustionSign { get; set; }
    }
}
