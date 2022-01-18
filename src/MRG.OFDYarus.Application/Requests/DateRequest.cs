using System;

namespace MRG.OFDYarus.Application.Requests
{
    public class DateRequest
    {
        public string Date { get; }
        public DateRequest(DateTime? date)
        {
            Date = !date.HasValue?null: date.Value.ToString("yyyy-MM-dd");
        }
    }
}
