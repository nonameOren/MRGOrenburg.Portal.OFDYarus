using System.Collections.Generic;

namespace MRG.OFDYarus.Application.Responses
{
    public class TradePointResponse
    { 
    /// <summary>
    /// Список торговых точек
    /// </summary>
    public Dictionary<string, TradePointsItem> Trade_points { get; set; }
    /// <summary>
    /// Количество торговых точек
    /// </summary>
    public int Count { get; set; }
}

/// <summary>
/// Торговая точка
/// </summary>
public class TradePointsItem
{
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
    public int Kktcount { get; set; }
    /// <summary>
    /// Адрес торговой точки
    /// </summary>
    public string Addr { get; set; }
}
}
