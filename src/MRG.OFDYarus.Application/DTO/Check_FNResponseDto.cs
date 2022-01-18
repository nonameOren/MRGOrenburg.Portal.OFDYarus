using System;

namespace MRG.OFDYarus.Application.DTO
{
    public class Check_FNResponseDto
    {
        /// <summary>
        /// Признак переполнения памяти ФН (True/ False) Архив памяти заполнен на 90 процентов
        /// </summary>
        public bool FiscalDriveMemoryExceededSign { get; set; }        
        /// <summary>
        /// Номер фискального накопителя (ФН)
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Дата последнего фискального документа (в Str) 
        /// </summary>
        public string Last_date_str { get; set; }
        /// <summary>
        /// Дата последнего фискального документа (в Unix Time, в секундах)
        /// </summary>
        public DateTime Last_date { get; set; }
        /// <summary>
        /// Информация о разрешении на прием документов (True/False)
        /// </summary>
        public bool Activated { get; set; }
        /// <summary>
        /// Признак исчерпания ресурса ФН ( значения True/False) до окончания срока 30 дней
        /// </summary>
        public bool FiscalDriveExhaustionSign { get; set; }
        /// <summary>
        /// Признак необходимости срочной замены ФН (True/ False) до окончания срока 3 дня
        /// </summary>
        public bool FiscalDriveReplaceRequiredSign { get; set; }
        /// <summary>
        /// Статус обработки последнего фискального документа
        /// </summary>        
        public string Desc { get; set; }
    }
}
