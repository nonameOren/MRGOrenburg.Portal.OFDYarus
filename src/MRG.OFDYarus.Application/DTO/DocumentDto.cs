using System;
using System.Collections.Generic;

namespace MRG.OFDYarus.Application.DTO
{
    public class DocumentDto
    {
        /// <summary>
        /// дата, время
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// телефон или электронный адрес покупателя. Только для кассовых чеков (БСО)
        /// </summary>
        public string BuyerPhoneOrAddress { get; set; }
        /// <summary>
        /// код документа "Кассовый чек" (всегда равен 3) <br/>
        /// код документа "БСО" (всегда равен 4)<br/>
        /// код документа "Кассовый чек коррекции" (всегда равен 31)<br/>
        /// код документа "БСО коррекции" (всегда равен 41)<br/>
        /// </summary>
        public DocumentType Code { get; set; }
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
        /// сумма уплаченная наличными
        /// </summary>
        public double CashTotalSum { get; set; }        
        /// <summary>
        /// ИТОГ, в копейках. Только для кассовых чеков (БСО)
        /// </summary>
        public double TotalSum { get; set; }
        /// <summary>
        /// номер чека за смену
        /// </summary>
        public int RequestNumber { get; set; }
        /// <summary>
        /// сумма уплаченная электронными средствами платежа, в копейках
        /// </summary>
        public double EcashTotalSum { get; set; }
        /// <summary>
        /// порядковый номер фискального документа
        /// </summary>
        public int FiscalDocumentNumber { get; set; }
        /// <summary>
        /// фискальный признак документа
        /// </summary>
        public long FiscalSign { get; set; }

        /// <summary>
        /// сумма НДС
        /// </summary>
        public double Nds { get; set; }
        /// <summary>
        /// Ставка НДС
        /// </summary>
        public VATRate VATRate { get; set; }
        /// <summary>
        /// признак расчета
        /// </summary>
        public OperationType OperationType { get; set; }        
        /// <summary>
        /// предмет расчета (см. Таблица предмет расчета). Только для кассовых чеков(БСО)
        /// </summary>        
        public IEnumerable<DocumentItemDto> Items { get; set; }
        /// <summary>
        /// Основание для коррекции. Только для кассовых чеков коррекции (БСО коррекции)
        /// </summary>
        public CorrectionBaseDto CorrectionBase { get; set; }
        /// <summary>
        /// Сумма коррекции. Только для кассовых чеков коррекции (БСО коррекции)
        /// </summary>
        public double CorrectionSum { get; set; }
        /// <summary>
        /// Тип коррекции. Только для кассовых чеков коррекции (БСО коррекции)
        /// </summary>
        public CorrectionType CorrectionType { get; set; }
    }

    /// <summary>
    /// предмет расчета (см. Таблица предмет расчета). Только для кассовых чеков(БСО)
    /// </summary>
    public class DocumentItemDto
    {
        /// <summary>
        /// Количество
        /// </summary>
        public float Quantity { get; set; }        
        /// <summary>
        /// цена за единицу с учетом скидок и наценок
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// наименование предмета расчета
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// стоимость товара с учетом скидок и наценок
        /// </summary>
        public double Sum { get; set; }
        /// <summary>
        /// ставка НДС
        /// </summary>
        public VATRate Nds { get; set; }
        /// <summary>
        /// признак предмета расчета
        /// </summary>
        public ProductType ProductType { get; set; }
        /// <summary>
        /// признак способа расчета
        /// </summary>
        public PaymentType PaymentType { get; set; }
    }

    /// <summary>
    /// Основание для коррекции. Только для кассовых чеков коррекции (БСО коррекции)
    /// </summary>
    public class CorrectionBaseDto
    {
        public string CorrectionName { get; set; }
        public DateTime CorrectionDocumentDate { get; set; }
        public string CorrectionDocumentNumber { get; set; }
    }

    public enum DocumentType
    {
        /// <summary>
        /// Кассовый чек
        /// </summary>
        CashReceipt = 3,
        /// <summary>
        /// БСО
        /// </summary>
        BSO = 4,
        /// <summary>
        /// Кассовый чек коррекции
        /// </summary>
        CashCorrectionReceipt = 31,
        /// <summary>
        /// БСО коррекции
        /// </summary>
        BSOCorrection = 41
    }
    /// <summary>
    /// Ставка НДС
    /// </summary>
    public enum VATRate
    {
        /// <summary>
        /// без НДС
        /// </summary>
        NdsNo = 6,
        /// <summary>
        /// ставке 0%
        /// </summary>
        Nds0  = 5,
        /// <summary>
        /// ставке 10%
        /// </summary>
        Nds10 = 2,
        /// <summary>
        /// ставке 10/110
        /// </summary>
        Nds10110 = 4,
        /// <summary>
        /// ставке 20%
        /// </summary>
        Nds20 = 1,
        /// <summary>
        /// ставке 20/120
        /// </summary>
        Nds20120 = 3       
    }

    /// <summary>
    /// признак способа расчета
    /// </summary>
    public enum PaymentType
    {
        Предоплата100 = 1,
        ЧастичнаяПредоплата,
        Аванс,
        ПолныйРасчет,
        ЧастичныйРасчетИкредит,
        ПередачаВкредит,
        оплатаКредита
    }

    /// <summary>
    /// признак предмета расчета
    /// </summary>
    public enum ProductType
    {
        Товар = 1,
        ПодакцизныйТовар,
        Работа,
        Услуга,
        СтавкаАзартнойИгры,
        ВыигрышАзартнойИгры,
        ЛотерейныйБилет,
        ВыигрышЛотереи,
        ПредоставлениеРИД,
        Платеж,
        АгентскоеВознаграждение,
        СоставнойПредметРасчета,
        ИнойПредметРасчета,
        ИмущественноеПраво,
        ВнереализационныйДоход,
        СтраховыеВзносы,
        ТорговыйСбор,
        КурортныйСбор,
        Залог
    }

    /// <summary>
    /// Тип корректировки
    /// </summary>
    public enum CorrectionType
    {
        CамостоятельнаяОперация,
        ОперацияПоПредписанию
    }
}
