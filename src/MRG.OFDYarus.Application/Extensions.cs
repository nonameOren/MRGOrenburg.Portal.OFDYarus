using MRG.OFDYarus.Application.DTO;
using MRG.OFDYarus.Application.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MRG.OFDYarus.Application
{
    public static class Extensions
    {
        public static Check_FNResponseDto ToDto(this Check_FNResponse doc) =>
            new Check_FNResponseDto
            {
                Activated = doc.Kkt.Activated,
                Desc = doc.Desc,
                FiscalDriveNumber = doc.Kkt.FiscalDriveNumber,
                FiscalDriveExhaustionSign = doc.Kkt.FiscalDriveExhaustionSign,
                FiscalDriveMemoryExceededSign = doc.Kkt.FiscalDriveMemoryExceededSign,
                FiscalDriveReplaceRequiredSign = doc.Kkt.FiscalDriveReplaceRequiredSign,
                Last_date = doc.Kkt.Last_date.ToUniversalTime(),
                Last_date_str = doc.Kkt.Last_date_str
            };
        public static IEnumerable<KktDto> ToDto(this KKTResponse doc) =>
            doc.Kkt.Where(i => i.Value.Last != "-/-/-").Select(i => new Application.DTO.KktDto
            {
                Address = i.Value.Address,
                FiscalDriveNumber = i.Key,
                KktRegid = i.Value.KktRegid,
                Last = i.Value.Last.ToDateTimeOrNull(),
                ReceiptCount = i.Value.ReceiptCount.ToInt(),
                Turnover = i.Value.Turnover.ToDouble()
            });            
        public static KKTResponseDto ToDto(this KKTv2Response doc) =>
            new KKTResponseDto
            {
                Kkt = doc.Kkt.Select(i => new Application.DTO.KktDto
                {
                    Address = i.Value.FirstOrDefault()?.Address,
                    FiscalDriveNumber = i.Key,
                    KktRegid = i.Value.FirstOrDefault()?.KktRegid,
                    Last = i.Value.FirstOrDefault()?.Last.ToDateTimeOrNull(),
                    ReceiptCount = i.Value.FirstOrDefault().ReceiptCount.ToInt(),
                    Turnover = i.Value.FirstOrDefault().Turnover.ToDouble()
                })
            };
        public static IEnumerable<TPDto> ToDto(this TPv1Response doc) =>
            doc.Trade_points.Select(i => i.ToDto());
        public static IEnumerable<TPDto> ToDto(this TPv2Response doc) =>
            doc.Trade_points.Select(i => i.ToDto());
        public static IEnumerable<TradePointDto> ToDto(this TradePointResponse doc) =>
            doc.Trade_points.Select(i => new TradePointDto
            {
                TPNumber = i.Key.ToInt(),
                Address = i.Value.Addr,
                Inn = i.Value.Inn,
                KktCount = i.Value.Kktcount,
                Name = i.Value.Name
            });
        public static IEnumerable<KKTbyTradePointDto> ToDto(this KKTbyTradePointResponse doc) =>
            doc.Kkt.Select(i => new KKTbyTradePointDto
            {
                Activated = i.Value.Activated,
                FactoryNumberKkt = i.Value.Factory_number_kkt,
                FiscalDriveNumber = i.Value.Factory_number_fn,
                Lastreq = i.Value.Lastreq.ToDateTimeOrNull(),
                Name = i.Value.Name,
                RegisterNumberKkt = i.Value.Name,
                Status = i.Value.Status
            });
        public static IEnumerable<KKTShiftDto> ToDto(this KKTShiftResponse doc) =>
            doc.Shifts.Select(i => i.ToDto());
        public static KKTShiftDto ToDto(this KKTShiftResponse_Item doc) =>
            new KKTShiftDto
            {
                CashTotalSum = doc.CashTotalSum.ToDouble(),
                CloseDateTime = doc.CloseDateTime.ToDateTimeOrNull(),
                EcashtotalSum = doc.EcashtotalSum.ToDouble(),
                OpenDateTime = (DateTime)doc.OpenDateTime.ToDateTimeOrNull(),
                ReceiptCount = doc.ReceiptCount,
                ShiftNumber = doc.ShiftNumber,
                Status = doc.Status,
                TotalSum = doc.TotalSum.ToDouble()
            };
        public static IEnumerable<DocumentsShiftItemDto> ToDto(this DocumentsShiftResponse doc) =>
            doc.items.Select(i => i.ToDto());
        public static DocumentsShiftItemDto ToDto(this DocumentsShiftItem doc) =>
            new DocumentsShiftItemDto
            {
                CashTotalSum = doc.cashTotalSum.ToDouble(),
                CorrectionSum = doc.correctionSum.ToDouble(),
                CreditSum = doc.creditSum.ToDouble(),
                DateTime = (DateTime)doc.dateTime.ToDateTimeOrNull(),
                Doctype = (DocType)Enum.Parse(typeof(DocType), doc.doctype),
                EcashTotalSum = doc.ecashTotalSum.ToDouble(),
                FiscalDocumentNumber = doc.fiscalDocumentNumber,
                FiscalSign = doc.fiscalSign,
                OperationType = (OperationType)doc.operationType,
                PrepaidSum = doc.prepaidSum.ToDouble(),
                ProvisionSum = doc.prepaidSum.ToDouble(),
                TotalSum = doc.totalSum.ToDouble()
            };
        public static CloseShiftReportDto ToDto(this CloseShiftReportResponse doc) =>
            new CloseShiftReportDto
            {
                Code = doc.code,
                DateTime = (DateTime)doc.dateTime.ToDateTimeOrNull(),
                FiscalDocumentNumber = doc.fiscalDocumentNumber,
                DocumentsQuantity = doc.documentsQuantity,
                FiscalDocumentFormatVer = doc.fiscalDocumentFormatVer,
                FiscalDriveExhaustionSign = doc.fiscalDriveExhaustionSign == 1,
                FiscalDriveMemoryExceededSign = doc.fiscalDriveMemoryExceededSign == 1,
                FiscalDriveNumber = doc.fiscalDriveNumber,
                fiscalDriveReplaceRequiredSign = doc.fiscalDriveReplaceRequiredSign == 1,
                FiscalSign = doc.fiscalSign,
                KktRegId = doc.kktRegId,
                NotTransmittedDocumentsDateTime = doc.notTransmittedDocumentsDateTime.ToUniversalTime(),
                NotTransmittedDocumentsQuantity = doc.notTransmittedDocumentsQuantity,
                OfdResponseTimeoutSign = doc.ofdResponseTimeoutSign == 1,
                Operator = doc._operator,
                ReceiptQuantity = doc.receiptQuantity,
                ShiftNumber = doc.shiftNumber,
                UserInn = doc.userInn
            };
        public static IEnumerable<DocumentDto> ToDto(this DocumentsRsponse doc) =>
            doc.Items.Select(i => i.ToDto());
        public static DocumentDto ToDto(this Document doc)
        {
            var dto = new DocumentDto
            {
                BuyerPhoneOrAddress = doc.BuyerPhoneOrAddress,
                CashTotalSum = doc.CashTotalSum.ToDouble(),
                Code = (DocumentType)doc.Code,
                CorrectionBase = doc.CorrectionBase?.ToDto(),
                CorrectionSum = doc.CorrectionSum.ToDouble(),
                CorrectionType = (CorrectionType)doc.CorrectionType,
                Date = doc.DateTime.ToUniversalTime(),
                EcashTotalSum = doc.EcashTotalSum.ToDouble(),
                FiscalDocumentNumber = doc.FiscalDocumentNumber,
                FiscalDriveNumber = doc.FiscalDriveNumber,
                FiscalSign = doc.FiscalSign,
                Items = doc.Items?.Select(i => i.ToDto()),
                KktRegId = doc.KktRegId,
                OperationType = (OperationType)doc.OperationType,
                RequestNumber = doc.RequestNumber,
                ShiftNumber = doc.ShiftNumber,
                TotalSum = doc.TotalSum.ToDouble()                
            };
            if (doc.Nds0 != 0)
            {
                dto.Nds = doc.Nds0.ToDouble();
                dto.VATRate = VATRate.Nds0;

                return dto;
            }
            if (doc.Nds10 != 0)
            {
                dto.Nds = doc.Nds10.ToDouble();
                dto.VATRate = VATRate.Nds10;

                return dto;
            }
            if (doc.Nds10110 != 0)
            {
                dto.Nds = doc.Nds10110.ToDouble();
                dto.VATRate = VATRate.Nds10110;

                return dto;
            }
            if (doc.Nds18 != 0)
            {
                dto.Nds = doc.Nds18.ToDouble();
                dto.VATRate = VATRate.Nds20;

                return dto;
            }
            if (doc.Nds18118 != 0)
            {
                dto.Nds = doc.Nds18118.ToDouble();
                dto.VATRate = VATRate.Nds20120;

                return dto;
            }
            if (doc.NdsNo != 0)
            {
                dto.Nds = doc.NdsNo.ToDouble();
                dto.VATRate = VATRate.NdsNo;

                return dto;
            }


            return dto;
        }
        public static DocumentItemDto ToDto(this DocumentItem doc) =>
            new DocumentItemDto
            {
                Name = doc.Name,
                Nds = (VATRate)doc.Nds,
                PaymentType = (PaymentType)doc.PaymentType,
                Price = doc.Price.ToDouble(),
                ProductType = (ProductType)doc.ProductType,
                Quantity = doc.Quantity,
                Sum = doc.Sum.ToDouble()
            };
        public static CorrectionBaseDto ToDto(this CorrectionBase doc) =>
            new CorrectionBaseDto
            {
                CorrectionDocumentDate = doc.CorrectionDocumentDate.ToUniversalTime(),
                CorrectionDocumentNumber = doc.CorrectionDocumentNumber,
                CorrectionName = doc.CorrectionName
            };
        public static TPDto ToDto(this TPv2Item doc) =>
            new TPDto
            {
                Address = doc.Address,
                Avgsum = doc.Avgsum.ToDouble(),
                FiscalDriverNumbers = doc.FiscalDriveNumber,
                Maxsum = doc.Maxsum.ToDouble(),
                Minsum = doc.Minsum.ToDouble(),
                ReceiptCount = doc.ReceiptCount,
                Turnover = doc.Turnover.ToDouble()
            };
        public static TPDto ToDto(this TPv1Item doc) =>
            new TPDto
            {
                Address = doc.Address,
                Avgsum = doc.Avgsum.ToDouble(),
                FiscalDriverNumbers = doc.FiscalDriverNumber,
                Maxsum = doc.Maxsum.ToDouble(),
                Minsum = doc.Minsum.ToDouble(),
                ReceiptCount = doc.ReceiptCount,
                Turnover = doc.Turnover.ToDouble()
            };
        public static GetChequeLinkDto ToDto(this GetChequeLinkResponse doc) =>
            new GetChequeLinkDto
            {
                DocType = doc.DocType,
                FiscalDocument = doc.FiscalDocument?.ToDto(),
                Link = doc.Link
            };
        public static IEnumerable<FiscalReportDto> ToDto(this FiscalReportResponse doc) =>
            doc.Items.Select(i => i.ToDto());
        public static FiscalReportDto ToDto(this FiscalReportItem doc) =>
            new FiscalReportDto { 
                AutoMode = doc.AutoMode == 1,
                BsoSign = doc.BsoSign == 1,
                Code = doc.Code,
                CorrectionReasonCode = doc.CorrectionReasonCode,
                DateTime = doc.DateTime.ToUniversalTime(),
                DocumentKktVersion = doc.DocumentKktVersion,
                EncryptionSign = doc.EncryptionSign ==1,
                ExciseDutyProductSign = doc.ExciseDutyProductSign ==1,
                FiscalDocumentFormatVer = doc.FiscalDocumentFormatVer,
                FiscalDocumentNumber = doc.FiscalDocumentNumber,
                FiscalDriveNumber = doc.FiscalDriveNumber,
                FiscalSign = doc.FiscalSign ==1,
                FnsUrl = doc.FnsUrl,
                GamblingSign = doc.GamblingSign ==1,
                InternetSign = doc.InternetSign ==1,
                KktNumber = doc.KktNumber,
                KktRegId = doc.KktRegId,
                KktVersion = doc.KktVersion,
                LotterySign = doc.LotterySign ==1,
                MachineNumber = doc.MachineNumber,
                OfdInn = doc.OfdInn,
                OfdName = doc.OfdName,
                OfflineMode = doc.OfflineMode,
                Operator = doc.Operator,
                PrintInMachineSign = doc.PrintInMachineSign ==1,
                RetailPlace = doc.RetailPlace,
                RetailPlaceAddress = doc.RetailPlaceAddress,
                SellerAddress = doc.SellerAddress,
                ServiceSign = doc.ServiceSign ==1,
                TaxationType = doc.TaxationType,
                User = doc.User,
                UserInn = doc.UserInn
            };
        public static int ToInt(this string str)
        {
            Int32 val = 0;
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            Int32.TryParse(str, out val);
            return val;
        }
        public static double ToDouble(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            var _int = str.ToInt();
            return (double)_int / 100;
        }
        public static double ToDouble(this int c) =>
            (double)c / 100;
        public static double ToDouble(this long c) =>
            (double)c / 100;

        public static DateTime ToUniversalTime(this int unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dateTime;
        }
        public static DateTime? ToDateTimeOrNull(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;
            //str = str.Split(',').FirstOrDefault();
            string[] pattern = { "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss,fff" };
            DateTime parsedDate;
            DateTime.TryParseExact(str, pattern, null,
                                   DateTimeStyles.None, out parsedDate);

            return parsedDate.Equals(new DateTime()) ? null : parsedDate;
        }
    }
}
