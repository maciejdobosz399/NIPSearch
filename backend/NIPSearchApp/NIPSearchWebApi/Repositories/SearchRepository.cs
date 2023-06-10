using NIPSearch.WebApi.Interfaces;
using NIPSearchWebApi.Contracts;
using NIPSearchWebApi.Utils;
using System.Net;

namespace NIPSearchWebApi.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly string apiUrl = "https://wl-api.mf.gov.pl/api/search/nip/"; //Can be also stored in appsettings.json of course

        public async Task<(EnterpreneurRequestContract, bool)> SearchAsync(string nip)
        {
            var enterpreneur = new EnterpreneurRequestContract();
            string now = DateTime.Now.ToString("yyyy-MM-dd");

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($"{apiUrl}{nip}?date={now}").Result;

                enterpreneur = await NIPUtils.ParseEnterpreneurFromHttpContentAsync(response.Content);

                return (enterpreneur, response.IsSuccessStatusCode);
            }
        }
    }
}