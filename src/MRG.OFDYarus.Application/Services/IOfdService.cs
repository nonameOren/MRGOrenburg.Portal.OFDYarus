using MRG.OFDYarus.Application.DTO;
using MRG.OFDYarus.Application.Requests;
using MRG.OFDYarus.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRG.OFDYarus.Application.Services
{
    public interface IOfdService
    {
        /// <summary>
        /// Метод возвращает ИНН организации или список ИНН организаций, которые выдали 
        /// права на работу с API для авторизованного пользователя
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> InnAsync();
        /// <summary>
        /// Метод возвращает данные о текущем состоянии кассы
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Check_FNResponseDto> Check_FNAsync(Check_FNRequest request);
        /// <summary>
        /// Метод возвращает агрегированную информацию о ККТ по номеру ФН. Данные
        /// собираются из отчетов о регистрации и перерегистрации.Метод не учитывает переезда
        /// ККТ из одной торговой точки в другую.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<KktDto>> KKTv1(DateRequest request);
        /// <summary>
        /// Метод возвращает данные о подключенных кассах (ФН) с разбиением данных в
        /// зависимости от адреса использования ККТ(Адрес места расчетов). Группировка
        /// происходит по адресам, указанным в отчетах о регистрации/перерегистрации.Добавлен
        /// подсчет агрегированной информации по документам как в случае передачи параметра
        /// date, так и за весь период работы ККТ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<KKTResponseDto> KKTv2(DateRequest request);
        /// <summary>
        /// Метод возвращает агрегированные данные по торговым точкам, собранным по отчетам о
        /// регистрации/перерегистрации.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<TPDto>> TPv1(DateRequest request);
        /// <summary>
        /// Метод возвращает агрегированные данные по торговым точкам, собранным по отчетам о
        /// регистрации/перерегистрации
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<TPDto>> TPv2(DateRequest request);
        /// <summary>
        /// Метод возвращает список торговых точек из личного кабинета.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TradePointDto>> TradePoint();
        /// <summary>
        /// Метод возвращает данные по ККТ, которые привязаны к торговой точке в личном
        /// кабинете клиента ОФД-Я.Метод недоступен на тестовом полигоне.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<KKTbyTradePointDto>> KKTbyTradePoint(TPNumberRequest request);
        /// <summary>
        /// Метод возвращает данные по Кассовым чекам и БСО за сутки по номеру фискального
        /// накопителя(номер ФН). Полученные результаты возможно скачать в файл result.txt
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<DocumentDto>> Documents(DocumentsRequest request);
        /// <summary>
        /// Метод возвращает список смен за указанный период по номеру фискального накопителя (номеру ФН).
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<IEnumerable<KKTShiftDto>> KKTShift(KKTShiftRequest request);
        /// <summary>
        /// Метод возвращает список документов по указанному номеру фискального накопителя
        /// (номеру ФН) и номеру смены.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<IEnumerable<DocumentsShiftItemDto>> DocumentsShift(DocumentsShiftRequest cmd);
        /// <summary>
        /// Метод возвращает отчет о закрытие смены по указанному номеру фискального
        /// накопителя(номеру ФН) и номеру смены.Данные зависят от версии фискального
        /// накопителя.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<CloseShiftReportDto> CloseShiftReport(CloseShiftReportRequest cmd);
        /// <summary>
        /// Метод по номеру фискального накопителя (номеру ФН) и номеру документа возвращает
        /// массив ФД и ссылки на их электронный вид на сайте ОФД-Я.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<GetChequeLinkDto> GetChequeLink(GetChequeLinkRequest_v1 cmd);
        /// <summary>
        /// Метод по номеру фискального накопителя (номеру ФН), номеру фискального документа
        /// (ФД) и фискальному признаку документа(ФПД) возвращает структуру документа и
        /// ссылку на его электронный вид на сайте ОФД-Я.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<GetChequeLinkDto> GetChequeLink(GetChequeLinkRequest_v2 cmd);
        /// <summary>
        /// Метод по регистрационному номеру ККТ (РНМ) и фискальному признаку документа
        /// (ФП) возвращает массив фискальных документов(ФД).
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<FiscalDocResponse> GetFiscalDoc(GetFiscalDocRequest_v1 cmd);
        /// <summary>
        /// Метод по фискальному признаку документа (ФПД), номеру фискального накопителя (ФН)
        /// и порядковому номеру фискального документа(ФД) возвращает полный фискальный
        /// документ.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<FiscalDocResponse> GetFiscalDoc(GetFiscalDocRequest_v2 cmd);
        /// <summary>
        /// Метод возвращает данные по Отчетам о регистрации, Отчётам об изменении параметров
        /// регистрации и Отчётам о закрытии фискального накопителя за указанный период времени
        /// по номеру фискального накопителя(номер ФН).
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<IEnumerable<FiscalReportDto>> GetFiscalReport(GetFiscalReportRequest cmd);
    }
}
