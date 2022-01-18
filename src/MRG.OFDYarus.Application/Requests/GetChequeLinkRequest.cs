namespace MRG.OFDYarus.Application.Requests
{
    public class GetChequeLinkRequest_v1
    {
        /// <summary>
        /// Номер фискального накопителя
        /// </summary>
        public string FiscalDriveNumber { get; set; }
        /// <summary>
        /// Порядковый номер фискального документа
        /// </summary>
        public int? FiscalDocumentNumber { get; set; }
    }

    public class GetChequeLinkRequest_v2: GetChequeLinkRequest_v1
    {
        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        public string FiscalSign { get; set; }
        public GetChequeLinkRequest_v2(long? fiscalSign)
        {
            if (fiscalSign.HasValue)
                FiscalSign = fiscalSign.Value.ToString();
        }
    }
}
