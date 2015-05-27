using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services.Exceptions;
using Services.Helpers;

namespace Services.Clients
{
    class SlackClient : ISlackClient
    {
        private String _authToken;

        public SlackClient(string auth_token)
        {
            _authToken = auth_token;
        }

        /// <summary>
        /// Wrapper for HttpClient
        /// </summary>
        /// <returns></returns>
        internal static HttpClient GetHttpClient()
        {
            var client = new HttpClient { BaseAddress = new Uri("https://slack.com/api/") };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        /// <summary>
        /// Make a GET request to a simple API.
        /// We assume all data is in the json object "data"
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="uri">Uri of the REST API resource.</param>
        /// <returns></returns>
        public async Task<T> Get<T>(string uri)
        {
            using (var client = GetHttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(uri + String.Format("&token={0}", _authToken)).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode(); // Throw if not a success code.
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonOutput = await response.Content.ReadAsStringAsync();
                            try
                            {
                                return JsonConvert.DeserializeObject<T>(jsonOutput, new JsonCustomConverter.BaseConverter());
                            }
                            catch (Exception e)
                            {
                                throw new SlackException("Deserialization error", e);
                            }
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    throw new SlackException("HTTP Request Error!", e);
                }

            }
            return default(T);
        }
    }
}
