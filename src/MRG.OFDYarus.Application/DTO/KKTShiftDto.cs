using System;

namespace MRG.OFDYarus.Application.DTO
{
    public class KKTShiftDto
    {
        /// <summary>
        /// Сумма
        /// </summary>
        public double TotalSum { get; set; }
        /// <summary>
        /// Сумма безнал 
        /// </summary>
        public double EcashtotalSum { get; set; }
        /// <summary>
        /// Номер смены
        /// </summary>
        public int ShiftNumber { get; set; }
        /// <summary>
        /// Дата и время закрытия (только если смена закрыта)
        /// </summary>
        public DateTime? CloseDateTime { get; set; }
        /// <summary>
        /// Сумма нал 
        /// </summary>
        public double CashTotalSum { get; set; }
        /// <summary>
        /// Дата и время открытия
        /// </summary>
        public DateTime OpenDateTime { get; set; }
        /// <summary>
        /// Кол-во чеков за смену
        /// </summary>
        public int ReceiptCount { get; set; }
        /// <summary>
        /// Статус (открыта/закрыта)
        /// </summary>
        public string Status { get; set; }
    }
}
