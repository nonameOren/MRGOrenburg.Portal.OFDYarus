namespace MRG.OFDYarus.Application.Requests
{
    public class CloseShiftReportRequest
    {
        /// <summary>
        /// Номер фискального накопителя
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Номер смены
        /// </summary>
        public long ShiftNumber { get; set; }
    }
}
