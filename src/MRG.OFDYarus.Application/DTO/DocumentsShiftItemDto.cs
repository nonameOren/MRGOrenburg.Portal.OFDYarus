using System;

namespace MRG.OFDYarus.Application.DTO
{
    public class DocumentsShiftItemDto
    {
        /// <summary>
        /// Тип документа
        /// </summary>
        public DocType Doctype { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public double TotalSum { get; set; }
        /// <summary>
        /// Дата и время фискального документа
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Сумма встречным предоставлением (иная форма оплаты)
        /// </summary>
        public double ProvisionSum { get; set; }
        /// <summary>
        /// Сумма безнал
        /// </summary>
        public double EcashTotalSum { get; set; }
        /// <summary>
        /// Сумма постоплатой (кредит)
        /// </summary>
        public double CreditSum { get; set; }
        /// <summary>
        /// Номер фискального документа
        /// </summary>
        public int FiscalDocumentNumber { get; set; }
        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        public long FiscalSign { get; set; }
        /// <summary>
        /// Признак расчета
        /// </summary>
        public OperationType OperationType { get; set; }
        /// <summary>
        /// Сумма предоплатой (аванс)
        /// </summary>
        public double PrepaidSum { get; set; }
        /// <summary>
        /// Сумма нал
        /// </summary>
        public double CashTotalSum { get; set; }
        /// <summary>
        /// Сумма коррекции. Только для кассовых чеков коррекции (БСО коррекции)
        /// </summary>
        public double CorrectionSum { get; set; }
    }

    public enum OperationType
    {
        Приход =1,
        ВозвратПрихода=2,
        Расход = 3,
        ВозвратPасхода = 4,
    }
}
