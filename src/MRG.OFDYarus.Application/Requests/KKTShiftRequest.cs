using System;

namespace MRG.OFDYarus.Application.Requests
{

    public class KKTShiftRequest
    {
        /// <summary>
        /// Номер фискального накопител
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Дата начала периода
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Дата окончания периода
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
