using MRG.OFDYarus.Api.Exceptions;
using MRG.OFDYarus.Api.Services.Clients;
using MRG.OFDYarus.Application;
using MRG.OFDYarus.Application.DTO;
using MRG.OFDYarus.Application.Requests;
using MRG.OFDYarus.Application.Responses;
using MRG.OFDYarus.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRG.OFDYarus.Api.Services
{
    public class OfdService: IOfdService
    {
        private readonly IOFDClient _client;
        public OfdService(IOFDClient client)
        {
            _client = client;
        }
        /// <summary>
        /// Метод возвращает ИНН организации или список ИНН организаций, которые выдали
        /// права на работу с API для авторизованного пользователя.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<string>> InnAsync() =>
            _client.PostAsync<IEnumerable<string>, EmptyRequest>("v1/inn", new EmptyRequest());
        /// <summary>
        /// Метод возвращает данные о текущем состоянии кассы
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Check_FNResponseDto> Check_FNAsync(Check_FNRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FiscalDriveNumber))
                throw new AppException("Не заполнен номер ФН");
            return (await _client.PostAsync<Check_FNResponse, Check_FNRequest>("v1/Check_FN", request)).ToDto();
        }
        /// <summary>
        /// Метод возвращает агрегированную информацию о ККТ по номеру ФН. Данные
        /// собираются из отчетов о регистрации и перерегистрации.Метод не учитывает переезда
        /// ККТ из одной торговой точки в другую.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<KktDto>> KKTv1(DateRequest request)
        {
            try
            {
                var responce = await _client.PostAsync<KKTResponse>("v1/KKT", request.Date is null ? new EmptyRequest() : request);
                return responce.ToDto();
            }
            catch (Exception ex)
            {
                throw new OfdException("error", ex.Message);
            }
        }
            
        /// <summary>
        /// Метод возвращает данные о подключенных кассах (ФН) с разбиением данных в
        /// зависимости от адреса использования ККТ(Адрес места расчетов). Группировка
        /// происходит по адресам, указанным в отчетах о регистрации/перерегистрации.Добавлен
        /// подсчет агрегированной информации по документам как в случае передачи параметра
        /// date, так и за весь период работы ККТ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<KKTResponseDto> KKTv2(DateRequest request)=>
            (await _client.PostAsync<KKTv2Response>("v2/KKT", request.Date is null ? new EmptyRequest() : request)).ToDto();
        /// <summary>
        /// Метод возвращает агрегированные данные по торговым точкам, собранным по отчетам о
        /// регистрации/перерегистрации.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TPDto>> TPv1(DateRequest request) =>
            (await _client.PostAsync<TPv1Response>("v1/TP", request.Date is null ? new EmptyRequest() : request)).ToDto();
        /// <summary>
        /// Метод возвращает агрегированные данные по торговым точкам, собранным по отчетам о
        /// регистрации/перерегистрации.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TPDto>> TPv2(DateRequest request) =>
            (await _client.PostAsync<TPv2Response>("v2/TP", request.Date is null ? new EmptyRequest() : request)).ToDto();
        /// <summary>
        /// Метод возвращает список торговых точек из личного кабинета.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TradePointDto>> TradePoint() =>
            (await _client.PostAsync<TradePointResponse>("v1/TradePoint", new EmptyRequest())).ToDto();
        /// <summary>
        /// Метод возвращает данные по ККТ, которые привязаны к торговой точке в личном
        /// кабинете клиента ОФД-Я.Метод недоступен на тестовом полигоне.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<KKTbyTradePointDto>> KKTbyTradePoint(TPNumberRequest request) =>
            (await _client.PostAsync<KKTbyTradePointResponse>("v1/KKTbyTradePoint", request)).ToDto();
        /// <summary>
        /// Метод возвращает данные по Кассовым чекам и БСО за сутки по номеру фискального
        /// накопителя(номер ФН). 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentDto>> Documents(DocumentsRequest request)        
        {
            if (string.IsNullOrWhiteSpace(request.FiscalDriveNumber))
                throw new AppException("Не заполнен номер ФН");
            if (string.IsNullOrWhiteSpace(request.Date) && string.IsNullOrWhiteSpace(request.ReceivingDate))
                throw new AppException("Не указаны параметра Data и ReceivingDate. Хотя бы один из них обязателен");

            return (await _client.PostAsync<DocumentsRsponse>("v1/documents", request)).ToDto();            
        }
        /// <summary>
        /// Метод возвращает список смен за указанный период по номеру фискального накопителя (номеру ФН).
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public async Task<IEnumerable<KKTShiftDto>> KKTShift(KKTShiftRequest request)
        {
            if(string.IsNullOrEmpty(request.FiscalDriveNumber))
                throw new AppException("Не заполнен номер ФН");

            return (await _client.PostAsync<KKTShiftResponse>("v1/KKTShift", request)).ToDto();
            
        }
        public async Task<IEnumerable<DocumentsShiftItemDto>> DocumentsShift(DocumentsShiftRequest request)
        {
            if (string.IsNullOrEmpty(request.FiscalDriveNumber))
                throw new AppException("Не заполнен номер ФН");
            
            if (request.ShiftNumber== 0)
                throw new AppException("Не заполнен Номер смены");
            
            if (request.DocType is null)
                throw new AppException("Не заполнен Тип документа");

            return (await _client.PostAsync<DocumentsShiftResponse>("v1/documentsShift", request)).ToDto();

        }
        public async Task<CloseShiftReportDto> CloseShiftReport(CloseShiftReportRequest request)
        {
            if (string.IsNullOrEmpty(request.FiscalDriveNumber))
                throw new AppException("Не заполнен номер ФН");

            if (request.ShiftNumber == 0)
                throw new AppException("Не заполнен Номер смены");

            return (await _client.PostAsync<CloseShiftReportResponse>("v1/closeShiftReport", request)).ToDto();
        }
        public async Task<GetChequeLinkDto> GetChequeLink(GetChequeLinkRequest_v1 request)
        {
            if (string.IsNullOrEmpty(request.FiscalDriveNumber))
                throw new AppException("Не заполнен номер ФН");

            if (!request.FiscalDocumentNumber.HasValue)
                throw new AppException("Не заполнен номер ФД");

            var response = await _client.PostAsync<IEnumerable<GetChequeLinkResponse>>("v1/getChequeLink", request);
            return response.FirstOrDefault()?.ToDto();
        }
        public async Task<GetChequeLinkDto> GetChequeLink(GetChequeLinkRequest_v2 request)
        {
            if (string.IsNullOrEmpty(request.FiscalDriveNumber))
                throw new AppException("Не заполнен номер ФН");

            if (!request.FiscalDocumentNumber.HasValue)
                throw new AppException("Не заполнен номер ФД");
            
            if (string.IsNullOrEmpty(request.FiscalSign))
                throw new AppException("Не заполнен Фискальный признак документа");

            return (await _client.PostAsync<GetChequeLinkResponse>("v2/getChequeLink", request)).ToDto();

        }
        public async Task<FiscalDocResponse> GetFiscalDoc(GetFiscalDocRequest_v1 request)
        {
            if (string.IsNullOrEmpty(request.KktRegId))
                throw new AppException("Не заполнен номер Регистрационный номер ККТ");

            var response = await _client.PostAsync<IEnumerable<FiscalDocResponse>>("v1/getFiscalDoc", request);
            return response.FirstOrDefault();
        }
        public Task<FiscalDocResponse> GetFiscalDoc(GetFiscalDocRequest_v2 request)
        {
            if (string.IsNullOrEmpty(request.FiscalDriveNumber))
                throw new AppException("Не заполнен номер ФН");
            
            return _client.PostAsync<FiscalDocResponse>("v2/getFiscalDoc", request);
        }
        public async Task<IEnumerable<FiscalReportDto>> GetFiscalReport(GetFiscalReportRequest request) =>
           (await _client.PostAsync<FiscalReportResponse>("v1/getFiscalReport", request)).ToDto();
    }    
}
