using Newtonsoft.Json;

namespace NIPSearchWebApi.Contracts
{
    public class EnterpreneurRequestContract
    {
        public string? Name { get; set; }
        public string? Nip { get; set; }
        public string? Regon { get; set; }

        [JsonProperty("residenceAddress")]
        public string? Address { get; set; }
    }
}