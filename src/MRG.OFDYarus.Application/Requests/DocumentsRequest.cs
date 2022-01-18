using System;
using System.Text.Json.Serialization;

namespace MRG.OFDYarus.Application.Requests
{
    public class DocumentsRequest
    {
        /// <summary>
        /// Номер фискального накопителя (номер ФН).
        /// </summary>
        public string FiscalDriveNumber { get; private set; }
        /// <summary>
        /// Дата в формате: YYYY-MM-DD
        /// </summary>
        [JsonIgnore(Condition= JsonIgnoreCondition.WhenWritingNull)]
        public string Date { get; private set; }
        /// <summary>
        /// Дата получение фискального документа в ОФД
        /// </summary>
        [JsonIgnore(Condition= JsonIgnoreCondition.WhenWritingNull)]
        public string ReceivingDate { get; private set; }
        /// <summary>
        /// Поиск по заданным реквизиту в параметре
        /// «field» и точному значению в параметре «value»
        /// </summary>
        [JsonIgnore(Condition= JsonIgnoreCondition.WhenWritingNull)]
        public Find Find { get; private set; }
        /// <summary>
        /// Поиск по заданным реквизиту в параметре 
        /// «field» и точному значению в параметре
        /// «value» в массиве Items.
        /// </summary>
        [JsonIgnore(Condition= JsonIgnoreCondition.WhenWritingNull)]
        public Find FindItem { get; private set; }
        /// <summary>
        /// Атрибут возвращает полученные
        /// фискальные документы в указанном
        /// интервале отсортированные по
        /// fiscalDocumentNumber по умолчанию в
        /// порядке возрастания.
        /// На данный атрибут наложено ограничение
        /// не более 3000 ФД, то есть для выбора
        /// бо́льшего числа ФД нужно разделить
        /// выборку на интервалы.
        /// Если данный атрибут не указан, то
        /// вернутся первые (относительно
        /// fiscalDocumentNumber) 3000 ФД.
        /// </summary>
        public string Interval { get; private set; }
        public DocumentsRequest(string fiscalDriveNumber,
            DateTime? date, Interval interval)
        {
            FiscalDriveNumber = fiscalDriveNumber;
            Date = date.HasValue ? date.Value.ToString("yyyy-MM-dd") : null;
            Interval = interval is null ? new Interval().ToString() : interval.ToString();
        }
        public DocumentsRequest(
            string fiscalDriveNumber, 
            DateTime? date, 
            DateTime? receivingDate, 
            Find find, 
            Find findItem, 
            Interval interval):this(fiscalDriveNumber,date, interval)
        {
            ReceivingDate = receivingDate.HasValue ? receivingDate.Value.ToString("yyyy-MM-dd") : null;
            Find = find;
            FindItem = findItem;            
        }

    }

    public class Interval
    {
        public long Start { get; private set; }
        public long End { get; private set; }
        public override string ToString()
        {
            return string.Format("{0},{1}",Start,End);
        }

        public Interval()
        {
            Start = 1;
            End = 3000;
        }
        public Interval(long start)
        {
            Start = start==0? 1: start;
            End = Start + 2999;
        }
    }

    public class Find
    {
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
