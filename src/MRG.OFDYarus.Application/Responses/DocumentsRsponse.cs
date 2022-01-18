using System.Collections.Generic;

namespace MRG.OFDYarus.Application.Responses
{
    public class DocumentsRsponse
    {
        public int Count { get; set; }
        public IEnumerable<Document> Items { get; set; }
    }

    public class Document
    {
        /// <summary>
        /// дата, время (в Unix Time, в секундах)
        /// </summary>
        public int DateTime { get; set; }
        /// <summary>
        /// телефон или электронный адрес покупателя. Только для кассовых чеков (БСО)
        /// </summary>
        public string BuyerPhoneOrAddress { get; set; }
        public int FiscalDocumentFormatVer { get; set; }
        /// <summary>
        /// код документа "Кассовый чек" (всегда равен 3) <br/>
        /// код документа "БСО" (всегда равен 4)<br/>
        /// код документа "Кассовый чек коррекции" (всегда равен 31)<br/>
        /// код документа "БСО коррекции" (всегда равен 41)<br/>
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
        /// сумма постоплаты (кредитами)
        /// </summary>
        public int CreditSum { get; set; }
        /// <summary>
        /// сумма по встречным предоставлениями
        /// </summary>
        public int ProvisionSum { get; set; }
        /// <summary>
        /// сумма уплаченная наличными, в копейках
        /// </summary>
        public int CashTotalSum { get; set; }
        /// <summary>
        /// кассир
        /// </summary>        
        public string Oper { get; set; }
        /// <summary>
        /// ИТОГ, в копейках. Только для кассовых чеков (БСО)
        /// </summary>
        public int TotalSum { get; set; }
        /// <summary>
        /// номер чека за смену
        /// </summary>
        public int RequestNumber { get; set; }
        /// <summary>
        /// сумма уплаченная электронными средствами платежа, в копейках
        /// </summary>
        public int EcashTotalSum { get; set; }
        /// <summary>
        /// порядковый номер фискального документа
        /// </summary>
        public int FiscalDocumentNumber { get; set; }
        /// <summary>
        /// фискальный признак документа
        /// </summary>
        public long FiscalSign { get; set; }
        /// <summary>
        /// сумма НДС чека по ставке 18%
        /// </summary>
        public int Nds18 { get; set; }
        /// <summary>
        /// признак расчета
        /// </summary>
        public int OperationType { get; set; }
        /// <summary>
        /// сумма предоплаты (авансами)
        /// </summary>
        public int PrepaidSum { get; set; }
        /// <summary>
        /// применяемая система налогообложения
        /// </summary>
        public int TaxationType { get; set; }
        /// <summary>
        /// предмет расчета (см. Таблица предмет расчета). Только для кассовых чеков(БСО)
        /// </summary>        
        public IEnumerable<DocumentItem> Items { get; set; }
        /// <summary>
        /// сумма НДС чека по расч. ставке 10/110
        /// </summary>       
        public int Nds10110 { get; set; }
        /// <summary>
        /// Основание для коррекции. Только для кассовых чеков коррекции (БСО коррекции)
        /// </summary>
       public CorrectionBase CorrectionBase { get; set; }
        /// <summary>
        /// сумма НДС чека по расч. ставке 18/118
        /// </summary>
        public int Nds18118 { get; set; }
        /// <summary>
        /// сумма расчета по чеку с НДС по ставке 0%
        /// </summary>
        public int Nds0 { get; set; }
        /// <summary>
        /// сумма НДС чека по ставке 10%
        /// </summary>
        public int Nds10 { get; set; }
        /// <summary>
        /// сумма расчета по чеку без НДС
        /// </summary>
        public int NdsNo { get; set; }
        /// <summary>
        /// Сумма коррекции. Только для кассовых чеков коррекции (БСО коррекции)
        /// </summary>
        public int CorrectionSum { get; set; }
        /// <summary>
        /// Тип коррекции. Только для кассовых чеков коррекции (БСО коррекции)
        /// </summary>
        public int CorrectionType { get; set; }
    }

    /// <summary>
    /// предмет расчета (см. Таблица предмет расчета). Только для кассовых чеков(БСО)
    /// </summary>
    public class DocumentItem
    {
        /// <summary>
        /// Количество
        /// </summary>
        public float Quantity { get; set; }        
        /// <summary>
        /// цена за единицу с учетом скидок и наценок
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// наименование предмета расчета
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// стоимость товара с учетом скидок и наценок
        /// </summary>
        public int Sum { get; set; }
        /// <summary>
        /// ставка НДС
        /// </summary>
        public int Nds { get; set; }
        /// <summary>
        /// признак предмета расчета
        /// </summary>
        public int ProductType { get; set; }
        /// <summary>
        /// признак способа расчета
        /// </summary>
        public int PaymentType { get; set; }
    }

    /// <summary>
    /// Основание для коррекции. Только для кассовых чеков коррекции (БСО коррекции)
    /// </summary>
    public class CorrectionBase
    {
        public string CorrectionName { get; set; }
        public int CorrectionDocumentDate { get; set; }
        public string CorrectionDocumentNumber { get; set; }
    }
}
