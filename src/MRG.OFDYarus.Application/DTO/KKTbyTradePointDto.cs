using System;

namespace MRG.OFDYarus.Application.DTO
{
    public class KKTbyTradePointDto
    {
        /// <summary>
        /// Номер фискального накопителя (номер ФН).
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Регистрационный номер ККТ (РНМ)
        /// </summary>
        public string RegisterNumberKkt { get; set; }
        /// <summary>
        /// Имя ККТ
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата и время последнего полученного фискального документа
        /// </summary>
        public DateTime? Lastreq { get; set; }
        /// <summary>
        /// Заводской номер ККТ
        /// </summary>
        public string FactoryNumberKkt { get; set; }
        /// <summary>
        /// Активность ККТ (True/False)
        /// </summary>
        public bool Activated { get; set; }
        /// <summary>
        /// Статус приема последнего фискального документа
        /// </summary>
        public string Status { get; set; }
    }
}
