using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MRG.OFDYarus.Application.Requests
{
    /*
     Минимальный период, за который выгружаются фискальные отчёты – 1 день, а
    максимальный – 7 дней.
    Если входными параметрами запроса являются:
    • только fiscalDriveNumber + startDate – то запрос выгружает фискальные отчёты всех
    типов за один день;
    • fiscalDriveNumber + startDate + endDate - то запрос выгружает фискальные отчёты всех
    типов за указанный период;
    • fiscalDriveNumber + startDate + fiscalDocType - то запрос выгружает указанные
    фискальные отчёты за один день;
    • fiscalDriveNumber + startDate + endDate + fiscalDocType - то запрос выгружает
    указанные фискальные отчёты за указанный период;
    Ответ не пустой при условии, что в указанном временном периоде есть подходящие
    (удовлетворяющие указанным параметрам) фискальные отчёты.
    При формировании ответа на запрос перед массивом информации с фискальными
    отчётами указывается число найденных документов (параметр count).
     */

    public class GetFiscalReportRequest
    {
        /// <summary>
        /// Заводской номер фискального накопителя(номер ФН).
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Дата начала периода.
        /// Например, если startDate:2021-01-01, то
        /// сутки считаются с 2021-01-01 00:00:00 до
        /// 2021-01-01 23:59:59.
        /// Формат: YYYY-MM-DD
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// Дата окончания периода.
        /// Например, если endDate:2021-07-01, то сутки
        /// считаются с 2021-07-01 00:00:00 до 2021-07-
        /// 01 23:59:59.
        /// Формат: YYYY-MM-DD
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; set; }
        /// <summary>
        /// Тип документа:
        /// 1 - Отчет о регистрации,
        /// 2 - Отчёт об изменении параметров регистрации,
        /// 3 - Отчёт о закрытии фискального накопителя.
        /// Можно указать один или несколько типов документов(в виде массива, например, "1,2" или "1,3").
        /// </summary>
        public string FiscalDocType { get; set; }

        public GetFiscalReportRequest(
            string fiscalDriveNumber,
            DateTime startDate,
            DateTime? endDate,
            IEnumerable<FiscalDocType> fiscalDocType)
        {
            FiscalDriveNumber = fiscalDriveNumber;
            StartDate = startDate.ToString("yyyy-MM-dd");
            EndDate = endDate.HasValue ? endDate.Value.ToString("yyyy-MM-dd"): null;
            FiscalDocType = "1,2,3";//fiscalDocType?.Select();
        }
    }

    public enum FiscalDocType
    {
        ОтчетОрегистрации=1,
        ОтчетОбИзмененииПараметровРегистрации,
        ОтчётОЗакрытииФискальногоНакопителя
    }
}
