using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TeaStall.ServiceManager
{
    public abstract class BaseServiceManager
    {
        public string SessionId { get; set; }
        public string BaseAddress = string.Empty;

        private HttpClient getClient()
        {
            // Create a client
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Keep-Alive", "false");
            client.Timeout = new TimeSpan(0, 10, 0);
            return client;
        }

        internal T GetWebApiModel<T>(string resource, JsonSerializer serializer)
        {
            if (BaseAddress == string.Empty) BaseAddress = ConfigurationManager.AppSettings["APIURL"];
            // Create a client
            var client = getClient();
            // Add an Accept header for JSON format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Add a new Request Message
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, BaseAddress + "/" + resource);
            requestMessage.Headers.Add("__SessionId", SessionId);

            var response = client.SendAsync(requestMessage).Result; // .GetAsync(resource).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                JsonReader reader = new JsonTextReader(new StringReader(json));
                var dto = serializer.Deserialize<T>(reader);

                return dto;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return default(T);
            }

            if (!string.IsNullOrEmpty(response.ReasonPhrase))
            {
                throw new ApplicationException(response.ReasonPhrase);
            }

            throw new ApplicationException("Unable to complete service request.");
        }


        internal T PostWebApiModel<T, TY>(string resource, TY request)
        {
            JsonSerializer serializer = new JsonSerializer();

            return this.PostWebApiModel<T, TY>(resource, request, serializer);
        }

        // New Method for POST
        internal T PostWebApiModel<T, TY>(string resource, TY request, JsonSerializer serializer)
        {
            if (BaseAddress == string.Empty) BaseAddress = ConfigurationManager.AppSettings["APIURL"];
            var client = getClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Add a new Request Message
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, BaseAddress + "/" + resource);
            requestMessage.Headers.Add("__SessionId", SessionId);
            requestMessage.Content = new ObjectContent<TY>(request, new JsonMediaTypeFormatter());

            var response = client.SendAsync(requestMessage).Result; // .GetAsync(resource).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                JsonReader reader = new JsonTextReader(new StringReader(json));
                var dto = serializer.Deserialize<T>(reader);
                //var dto = response.Content.ReadAsAsync<T>().Result;
                return dto;
            }

            if (!string.IsNullOrEmpty(response.ReasonPhrase))
            {
                throw new ApplicationException(response.ReasonPhrase);
            }

            throw new ApplicationException("Unable to complete service request.");
        }

        internal T PutWebApiModel<T, TY>(string resource, TY request)
        {
            JsonSerializer serializer = new JsonSerializer();
            return this.PutWebApiModel<T, TY>(resource, request, serializer);
        }

        // New Method for PUT
        internal T PutWebApiModel<T, TY>(string resource, TY request, JsonSerializer serializer)
        {
            if (BaseAddress == string.Empty) BaseAddress = ConfigurationManager.AppSettings["APIURL"];
            var client = getClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, BaseAddress + "/" + resource);
            requestMessage.Headers.Add("__SessionId", SessionId);
            requestMessage.Content = new ObjectContent<TY>(request, new JsonMediaTypeFormatter());

            var response = client.SendAsync(requestMessage).Result; // .GetAsync(resource).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                //JsonSerializer serializer = new JsonSerializer();
                var json = response.Content.ReadAsStringAsync().Result;
                JsonReader reader = new JsonTextReader(new StringReader(json));
                var dto = serializer.Deserialize<T>(reader);
                return dto;
            }

            if (!string.IsNullOrEmpty(response.ReasonPhrase))
            {
                throw new ApplicationException(response.ReasonPhrase);
            }

            throw new ApplicationException("Unable to complete service request.");
        }

        internal T DeleteWebApiModel<T>(string resource)
        {
            var serializer = new JsonSerializer();
            return DeleteWebApiModel<T>(resource, serializer);
        }

        internal T DeleteWebApiModel<T>(string resource, JsonSerializer serializer)
        {
            if (BaseAddress == string.Empty) BaseAddress = ConfigurationManager.AppSettings["APIURL"];
            var client = getClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, BaseAddress + "/" + resource);
            requestMessage.Headers.Add("__SessionId", SessionId);

            var response = client.SendAsync(requestMessage).Result; // .GetAsync(resource).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                //JsonSerializer serializer = new JsonSerializer();
                var json = response.Content.ReadAsStringAsync().Result;
                JsonReader reader = new JsonTextReader(new StringReader(json));
                var dto = serializer.Deserialize<T>(reader);
                return dto;
            }

            if (!string.IsNullOrEmpty(response.ReasonPhrase))
            {
                throw new ApplicationException(response.ReasonPhrase);
            }

            throw new ApplicationException("Unable to complete service request.");
        }
    }
}
