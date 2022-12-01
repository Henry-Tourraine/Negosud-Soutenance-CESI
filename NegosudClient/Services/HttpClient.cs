using NegosudAPI.Utils.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Linq;

namespace NegosudClient.Services
{
    public class Client<T, U>
    {
        public HttpClient Http { get; set; }
        public string BaseURL { get; set; }

        public string Route { get; set; }

        public Client(string route)
        {
            Http = new HttpClient();
            BaseURL = "http://localhost:5476"+route;
        }

        
        public async Task<T> GenericCreate(T element)
        {

            var content = JsonSerializer.Serialize(element);

            var request = new HttpRequestMessage(HttpMethod.Post, BaseURL);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(content, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var created = JsonSerializer.Deserialize<T>(responseContent);

            return created;
        }
        public async Task<T> GenericUpdate(T element)
        {
            var content = JsonSerializer.Serialize(element);

            var request = new HttpRequestMessage(HttpMethod.Put, BaseURL);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(content, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var updated = JsonSerializer.Deserialize<T>(responseContent);

            return updated;
        }
        public async Task GenericDelete(U id)
        {
            string e = "";
            if (id.GetType().Name != "Int32")
            {
                e = id.ToString();
            }
            else
            {
                e = id.ToString();
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, BaseURL + "/"+e);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            
            var response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var updated = JsonSerializer.Deserialize<UtilisateurDTO>(responseContent);

        }

        public async Task<List<T>> GenericFindAll()
        {
           

            var request = new HttpRequestMessage(HttpMethod.Get, BaseURL);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            

            var response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var found = JsonSerializer.Deserialize<List<T>>(responseContent);

            return found;
        }


        public async Task<T> GenericFind(U id)
        {
            string e = "";
            if (id.GetType().Name != "Int32")
            {
                e = id.ToString();
            }
            else
            {
                e = id.ToString();
            }

            var request = new HttpRequestMessage(HttpMethod.Get, BaseURL +"/"+e);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           

            var response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var found = JsonSerializer.Deserialize<T>(responseContent);

            return found;
        }
    }
}
