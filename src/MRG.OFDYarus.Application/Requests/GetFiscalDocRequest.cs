namespace MRG.OFDYarus.Application.Requests
{
    public class GetFiscalDocRequest_v1
    {
        /// <summary>
        /// Регистрационный номер ККТ (РНМ)
        /// </summary>
        public string KktRegId { get; set; }
        /// <summary>
        /// Фискальный признак документа (ФПД)
        /// </summary>
        public long FiscalSign { get; set; }
    }

    public class GetFiscalDocRequest_v2 {
        /// <summary>
        /// Фискальный признак документа (ФПД)
        /// </summary>
        public long FiscalSign { get; set; }
        /// <summary>
        /// Номер фискального накопителя(ФН)
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Порядковый номер фискального документа(ФД)
        /// </summary>
        public int FiscalDocumentNumber { get; set; }


    }
}
