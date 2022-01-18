using System.Collections.Generic;

namespace MRG.OFDYarus.Application.Responses
{
    public class KKTbyTradePointResponse
    {
        public Dictionary<string, KKTbyTradePointItem> Kkt { get; set; }
        /// <summary>
        /// Количество ККТ в торговой точке
        /// </summary>
        public int Count { get; set; }
    }

    public class KKTbyTradePointItem
    {
        /// <summary>
        /// Номер фискального накопителя (номер ФН).
        /// </summary>
        public string Factory_number_fn { get; set; }
        /// <summary>
        /// Регистрационный номер ККТ (РНМ)
        /// </summary>
        public string Register_number_kkt { get; set; }
        /// <summary>
        /// Имя ККТ
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата и время последнего полученного фискального документа
        /// </summary>
        public string Lastreq { get; set; }
        /// <summary>
        /// Заводской номер ККТ
        /// </summary>
        public string Factory_number_kkt { get; set; }
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
