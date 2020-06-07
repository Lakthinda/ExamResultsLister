using ExamResultsLister.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamResultsLister.Services
{
    /// <summary>
    /// Consume ExamResults 3rd Party API
    /// </summary>
    public class ExamAPIService : IExamAPIService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<ExamAPIService> _logger;
        private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;

        public ExamAPIService(IHttpClientFactory clientFactory,
                              ILogger<ExamAPIService> logger,
                              IAsyncPolicy<HttpResponseMessage> retryPolicy
                              )
        {
            _clientFactory = clientFactory;
            _logger = logger;
            _retryPolicy = retryPolicy;
        }

        /// <summary>
        /// Returns list of ExamSubjects
        /// </summary>
        /// <returns></returns>
        public async Task<List<ExamSubject>> GetExamResults()
        {
            var APIURL = "https://cpacodingchallenge.azurewebsites.net/api/results";
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get,
                                                    APIURL);
                request.Headers.Add("Accept", "application/json");
                var client = _clientFactory.CreateClient();
                                
                var response = await _retryPolicy.ExecuteAsync(() =>
                        client.SendAsync(request));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var examResults = JsonConvert.DeserializeObject<List<ExamSubject>>(result);
                    return examResults;
                }
                else
                {
                    _logger.LogError($"Response: {response.StatusCode}, Content: {response.Content}");
                    return null;
                }


            }
            catch (Exception e)
            {
                _logger.LogError($"Response: {e.Message}", e);
                return null;
            }
        }
    }
}
