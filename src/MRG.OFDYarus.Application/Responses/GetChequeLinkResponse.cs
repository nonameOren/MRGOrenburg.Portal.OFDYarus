namespace MRG.OFDYarus.Application.Responses
{
    /**/
    public class GetChequeLinkResponse
    {
        /// <summary>
        /// Тип документа. Можно указать один или несколько типов документов <br/>
        /// receipt – кассовый чек,<br/>
        /// bso - бланк строгой отчетности,<br/>
        /// receipt_correction – кассовый чек коррекции, bso_correction – БСО коррекции,<br/>
        /// open_shift – отчет об открытии смены,<br/>
        /// close_shift – отчет о закрытии смены<br/>
        /// </summary>
        public string DocType { get; set; }
        /// <summary>
        /// Ссылка на фискальный документ
        /// </summary>
        public string Link { get; set; }
        public Document FiscalDocument { get; set; }
    }
}
