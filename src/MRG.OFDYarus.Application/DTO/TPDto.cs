using System;
using System.Collections.Generic;

namespace MRG.OFDYarus.Application.DTO
{

    public class TPDto
    {
        /// <summary>
        /// Адрес торговой точки
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Список ФН (номеров фискального накопителя)
        /// </summary>
        public IEnumerable<string> FiscalDriverNumbers { get; set; }
        /// <summary>
        /// Минимальный чек в торговой точке
        /// </summary>
        public Double Minsum { get; set; }
        /// <summary>
        /// Максимальный чек в торговой точке
        /// </summary>
        public Double Maxsum { get; set; }
        /// <summary>
        /// Средний чек
        /// </summary>
        public Double Avgsum { get; set; }
        /// <summary>
        /// Сумма переданных данных в ФНС
        /// </summary>
        public Double Turnover { get; set; }
        /// <summary>
        /// Количество операций
        /// </summary>
        public int ReceiptCount { get; set; }
    }
}
