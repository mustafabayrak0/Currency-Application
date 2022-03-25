using Newtonsoft.Json;

namespace CurrencyApplication.Models
{
    public class Currency
    {
        public string USD { get; set; }
        public string TRY { get; set; }
        public string GBP { get; set; }
        public string EUR { get; set; }

        [JsonProperty("base")]
        public string Base { get; set;}
        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public class Result
    {
        public  string TRY { get; set; }
        public  string USD { get; set; }
        public  string GBP { get; set; }
        public  string EUR { get; set; }
    }
}
