namespace MRG.OFDYarus.Application.Responses
{
    public class FiscalReportResponse
    {
        public int Count { get; set; }
        public FiscalReportItem[] Items { get; set; }
    }
    public class FiscalReportItem
    {
        /// <summary>
        /// Дата, время
        /// </summary>
        public int DateTime { get; set; }
        /// <summary>
        /// Номер версии ФФД
        /// </summary>
        public int FiscalDocumentFormatVer { get; set; }
        /// <summary>
        /// Код типа фискального документа
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// Номер ФД
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// ИНН ОФД
        /// </summary>
        public string OfdInn { get; set; }
        /// <summary>
        /// Адрес электронной почты отправителя чека
        /// </summary>
        public string SellerAddress { get; set; }
        /// <summary>
        /// Признак автоматического режима
        /// </summary>
        public int AutoMode { get; set; }
        /// <summary>
        /// Признак проведения азартных игр
        /// </summary>
        public int GamblingSign { get; set; }
        /// <summary>
        /// ИНН кассира
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// Наименование ОФД
        /// </summary>
        public string OfdName { get; set; }
        /// <summary>
        /// Код причины перерегистрации
        /// </summary>
        public int[] CorrectionReasonCode { get; set; }
        /// <summary>
        /// Адрес сайта ФНС
        /// </summary>
        public string FnsUrl { get; set; }
        /// <summary>
        /// Номер ФД
        /// </summary>
        public int FiscalDocumentNumber { get; set; }
        /// <summary>
        /// Системы налогообложения
        /// </summary>
        public int TaxationType { get; set; }
        /// <summary>
        /// Признак расчетов за услуги
        /// </summary>
        public int ServiceSign { get; set; }
        /// <summary>
        /// Признак автономного режима
        /// </summary>
        public int OfflineMode { get; set; }
        /// <summary>
        /// Признак ККТ для расчетов только в Интернет
        /// </summary>
        public int InternetSign { get; set; }
        /// <summary>
        /// Версия ФФД ККТ
        /// </summary>
        public int DocumentKktVersion { get; set; }
        /// <summary>
        /// ИНН пользователя
        /// </summary>
        public string UserInn { get; set; }
        /// <summary>
        /// Регистрационный номер ККТ
        /// </summary>
        public string KktRegId { get; set; }
        /// <summary>
        /// Версия ККТ
        /// </summary>
        public string KktVersion { get; set; }
        /// <summary>
        /// Признак проведения лотереи
        /// </summary>
        public int LotterySign { get; set; }
        /// <summary>
        /// Признак торговли подакцизными товарами
        /// </summary>
        public int ExciseDutyProductSign { get; set; }
        /// <summary>
        /// Признак шифрования
        /// </summary>
        public int EncryptionSign { get; set; }
        /// <summary>
        /// Заводской номер ККТ
        /// </summary>
        public string KktNumber { get; set; }
        /// <summary>
        /// Адрес расчетов
        /// </summary>
        public string RetailPlaceAddress { get; set; }
        /// <summary>
        /// Номер автомата
        /// </summary>
        public string MachineNumber { get; set; }
        /// <summary>
        /// ФПД
        /// </summary>
        public int FiscalSign { get; set; }
        /// <summary>
        /// Признак АС БСО
        /// </summary>
        public int BsoSign { get; set; }
        /// <summary>
        /// Наименование пользователя
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Место расчетов
        /// </summary>
        public string RetailPlace { get; set; }
        /// <summary>
        /// Признак установки принтера в автомате
        /// </summary>
        public int PrintInMachineSign { get; set; }
    }
}
