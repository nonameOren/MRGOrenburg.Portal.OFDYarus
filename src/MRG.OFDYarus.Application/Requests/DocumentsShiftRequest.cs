using MRG.OFDYarus.Application.DTO;
using System.Collections.Generic;

namespace MRG.OFDYarus.Application.Requests
{
    public class DocumentsShiftRequest
    {
        public string FiscalDriveNumber { get; set; }
        public int ShiftNumber { get; set; }
        public IEnumerable<DocType> DocType { get; set; }
    }
}
