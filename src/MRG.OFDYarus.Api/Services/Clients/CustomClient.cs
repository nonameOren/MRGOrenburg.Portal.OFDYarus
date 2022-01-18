using Convey.HTTP;
using MRG.OFDYarus.Api.Exceptions;
using MRG.OFDYarus.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MRG.OFDYarus.Application.Services;

namespace MRG.OFDYarus.Api.Services.Clients
{
    public class CustomClient: IOFDClient
    {
        private readonly string _url;
        private readonly IHttpClient _client;
        public CustomClient(HttpClientOptions options, IHttpClient client)
        {
            _url = options.Services["ofd_yarus"];
            _client = client;

            Dictionary<string, string> header = new Dictionary<string, string>
            {
                ["Ofdapitoken"] = "<Token>",
                ["Content-Type"] = "application/json"
            };
            _client.SetHeaders(header);            
        }

        public async Task<T> PostAsync<T,R>(string url, R request)
        {            
            var response = await _client.PostAsync($"{_url}/{url}", request);
            if (!response.IsSuccessStatusCode)
                throw new OfdException(0, response.ReasonPhrase);

            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }
            catch (Exception ex)
            {
                var error = JsonConvert.DeserializeObject<ErrorDto>(content);
                throw new OfdException(error.Code, error.Desc);
            }
        }

        public async Task<T> PostAsync<T>(string url, object request)
        {
            var response = await _client.PostAsync($"{_url}/{url}", request);
            if (!response.IsSuccessStatusCode)
                throw new OfdException(0, response.ReasonPhrase);
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                var ofdError = JsonConvert.DeserializeObject<ErrorDto>(content);
                if(!string.IsNullOrWhiteSpace(ofdError.Desc))
                    throw new OfdException(ofdError.Code, ofdError.Desc);
            }
            catch (OfdException ex)
            {
                throw ex;
            }

            try
            {
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }
}
