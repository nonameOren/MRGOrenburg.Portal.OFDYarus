using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRG.OFDYarus.Application.Responses
{

    public class FiscalDocResponse
    {
        public Meta meta { get; set; }
        public Requestmessage requestmessage { get; set; }
        public Responsemessage responsemessage { get; set; }
        public string id { get; set; }
    }

    public class Meta
    {
        public bool flcError { get; set; }
        public int rawDataSize { get; set; }
        public string userInn { get; set; }
        public long kktRegId { get; set; }
        public int docId { get; set; }
        public int aVersion { get; set; }
        public long receiveTimeMs { get; set; }
        public long dateTimeMs { get; set; }
        public string uuid { get; set; }
        public int tagNumber { get; set; }
        public int flcVersion { get; set; }
        public long fsId { get; set; }
        public int ffdVersion { get; set; }
    }

    public class Requestmessage
    {
        public int dateTime { get; set; }
        public int provisionSum { get; set; }
        public int fiscalDocumentFormatVer { get; set; }
        public int code { get; set; }
        public string fiscalDriveNumber { get; set; }
        public int shiftNumber { get; set; }
        public int requestNumber { get; set; }
        public DocumentItem items_0 { get; set; }
        public string fnsUrl { get; set; }
        public int ecashTotalSum { get; set; }
        public int fiscalDocumentNumber { get; set; }
        public int nds18 { get; set; }
        public string buyerPhoneOrAddress { get; set; }
        public string userInn { get; set; }
        public string kktRegId { get; set; }
        public int creditSum { get; set; }
        public int cashTotalSum { get; set; }
        public int appliedTaxationType { get; set; }
        public int totalSum { get; set; }
        public string machineNumber { get; set; }
        public string retailPlaceAddress { get; set; }
        public int fiscalSign { get; set; }
        public int operationType { get; set; }
        public int prepaidSum { get; set; }
        public DocumentItem[] items { get; set; }
        public string retailPlace { get; set; }
        public string user { get; set; }
    }

    public class Responsemessage
    {
        public int dateTime { get; set; }
        public int fiscalDocumentNumber { get; set; }
        public string fiscalDriveNumber { get; set; }
        public string ofdInn { get; set; }
        public string ofdFiscalSign { get; set; }
        public Messageforfn messageForFN { get; set; }
    }

    public class Messageforfn
    {
        public int ofdResponseCode { get; set; }
    }

    
}
