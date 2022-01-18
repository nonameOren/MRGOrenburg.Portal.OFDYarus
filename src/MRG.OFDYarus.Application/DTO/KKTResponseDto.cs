using System;
using System.Collections.Generic;

namespace MRG.OFDYarus.Application.DTO
{
    public class KKTResponseDto
    {
        /// <summary>
        /// Массив ККТ(номеров ФН)
        /// </summary>
        public IEnumerable<KktDto> Kkt { get; set; }
    }

    public class KktDto
    {
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Адрес ККТ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Время последнего успешно полученного документа
        /// </summary>
        public DateTime? Last { get; set; }
        ///// <summary>
        ///// Регистрационный номер ККТ
        ///// </summary>
        public string KktRegid { get; set; }
        ///// <summary>
        ///// Сумма переданных данных в ФНС
        ///// </summary>
        public double Turnover { get; set; }
        ///// <summary>
        ///// Количество операций
        ///// </summary>
        public long ReceiptCount { get; set; }
    }
}
