using System.Collections.Generic;

namespace MRG.OFDYarus.Application.Responses
{
    public class KKTShiftResponse
    {
        /// <summary>
        /// Номер фискального накопителя (номер ФН)
        /// </summary>
        public string FiscalDriveNumber { get; set; }

        public IEnumerable<KKTShiftResponse_Item> Shifts { get; set; }
    }
    /// <summary>
    /// Смены
    /// </summary>
    public class KKTShiftResponse_Item
    {
        /// <summary>
        /// Сумма в копейках
        /// </summary>
        public int TotalSum { get; set; }
        /// <summary>
        /// Сумма безнал в копейках
        /// </summary>
        public int EcashtotalSum { get; set; }
        /// <summary>
        /// Номер смены
        /// </summary>
        public int ShiftNumber { get; set; }
        /// <summary>
        /// Дата и время закрытия (только если смена закрыта)
        /// </summary>
        public string CloseDateTime { get; set; }
        /// <summary>
        /// Сумма нал в копейках
        /// </summary>
        public int CashTotalSum { get; set; }
        /// <summary>
        /// Дата и время открытия
        /// </summary>
        public string OpenDateTime { get; set; }
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
