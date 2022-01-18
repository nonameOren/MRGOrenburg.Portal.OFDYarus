using System;

namespace MRG.OFDYarus.Application.DTO
{
    public class CloseShiftReportDto
    {
        /// <summary>
        /// дата, время
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// признак переполнения памяти ФН
        /// </summary>
        public bool FiscalDriveMemoryExceededSign { get; set; }
        /// <summary>
        /// признак превышения времени ожидания ответа ОФД
        /// </summary>
        public bool OfdResponseTimeoutSign { get; set; }

        public int FiscalDocumentFormatVer { get; set; }
        /// <summary>
        /// код документа (всегда равен 5)
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// ИНН пользователя
        /// </summary>
        public string UserInn { get; set; }
        /// <summary>
        /// регистрационный номер ККТ
        /// </summary>
        public string KktRegId { get; set; }
        /// <summary>
        /// заводской номер фискального накопителя
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// номер смены
        /// </summary>
        public int ShiftNumber { get; set; }
        /// <summary>
        /// количество чеков (БСО) за смену
        /// </summary>
        public int ReceiptQuantity { get; set; }
        /// <summary>
        /// кассир
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// признак необходимости срочной замены ФН
        /// </summary>
        public bool fiscalDriveReplaceRequiredSign { get; set; }
        /// <summary>
        /// кол-во непереданных документов ФД
        /// </summary>
        public int NotTransmittedDocumentsQuantity { get; set; }
        /// <summary>
        /// порядковый номер фискального документа
        /// </summary>
        public int FiscalDocumentNumber { get; set; }
        /// <summary>
        /// фискальный признак документа
        /// </summary>
        public long FiscalSign { get; set; }
        /// <summary>
        /// дата и время первого из непереданных ФД
        /// </summary>
        public DateTime NotTransmittedDocumentsDateTime { get; set; }
        /// <summary>
        /// количество фискальных документов за смену
        /// </summary>
        public int DocumentsQuantity { get; set; }
        /// <summary>
        /// признак исчерпания ресурса ФН
        /// </summary>
        public bool FiscalDriveExhaustionSign { get; set; }
    }
}
