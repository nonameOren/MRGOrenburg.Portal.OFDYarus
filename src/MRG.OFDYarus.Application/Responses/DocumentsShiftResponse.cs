using System.Collections.Generic;

namespace MRG.OFDYarus.Application.Responses
{
    public class DocumentsShiftResponse
    {
        /// <summary>
        /// Номер фискального накопителя
        /// </summary>
        public string fiscalDriveNumber { get; set; }
        /// <summary>
        /// Номер смены
        /// </summary>
        public string shiftNumber { get; set; }
        /// <summary>
        /// Список документов
        /// </summary>
        public IEnumerable<DocumentsShiftItem> items { get; set; }
    }

    /// <summary>
    /// Список документов
    /// </summary>
    public class DocumentsShiftItem
    {
        /// <summary>
        /// Тип документа
        /// </summary>
        public string doctype { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public int totalSum { get; set; }
        /// <summary>
        /// Дата и время фискального документа
        /// </summary>
        public string dateTime { get; set; }
        /// <summary>
        /// Сумма встречным предоставлением (иная форма оплаты)
        /// </summary>
        public int provisionSum { get; set; }
        /// <summary>
        /// Сумма безнал
        /// </summary>
        public int ecashTotalSum { get; set; }
        /// <summary>
        /// Сумма постоплатой (кредит)
        /// </summary>
        public int creditSum { get; set; }
        /// <summary>
        /// Номер фискального документа
        /// </summary>
        public int fiscalDocumentNumber { get; set; }
        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        public long fiscalSign { get; set; }
        /// <summary>
        /// Признак расчета
        /// </summary>
        public int operationType { get; set; }
        /// <summary>
        /// Сумма предоплатой (аванс)
        /// </summary>
        public int prepaidSum { get; set; }
        /// <summary>
        /// Сумма нал
        /// </summary>
        public int cashTotalSum { get; set; }
        /// <summary>
        /// Сумма коррекции. Только для кассовых чеков коррекции (БСО коррекции)
        /// </summary>
        public int correctionSum { get; set; }
    }
}
