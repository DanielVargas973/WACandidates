using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WACandidates.Classes.Model;

namespace WACandidates.Classes.APIConsummer
{
    public class CandidateConsummerService
    {
        private HttpClient client;
        public async Task<CandidateModel[]> GetCandidatesAsync()
        {
            try
            {
                client = new HttpClient
                {
                    BaseAddress = new Uri("http://jsonplaceholder.typicode.com")
                };
                CandidateModel[] candidateModel = null;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                var resp = client.GetAsync("/users/");
                HttpResponseMessage response = resp.Result;
                if (response.IsSuccessStatusCode)
                {
                    candidateModel = await response.Content.ReadAsAsync<CandidateModel[]>();
                }
                return candidateModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}