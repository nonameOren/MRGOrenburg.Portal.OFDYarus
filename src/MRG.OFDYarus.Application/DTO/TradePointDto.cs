namespace MRG.OFDYarus.Application.DTO
{
    public class TradePointDto
    {
        /// <summary>
        /// Номер торговой точки
        /// </summary>
        public int TPNumber { get; set; }
        /// <summary>
        /// ИНН компании
        /// </summary>
        public string Inn { get; set; }
        /// <summary>
        /// Наименование торговой точки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количество касс в торговой точке
        /// </summary>
        public int KktCount { get; set; }
        /// <summary>
        /// Адрес торговой точки
        /// </summary>
        public string Address { get; set; }
    }
}
