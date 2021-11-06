namespace ApiClient
{
    public class CryptoModel
    {
        public string asset_id { get; set; }
        public string name { get; set; }
        public string volume_1hrs_usd { get; set; }
        public string volume_1day_usd { get; set; }
        public string volume_1mth_usd { get; set; }
        public string price_usd { get; set; }
        public string type_is_crypto { get; set; }
    }
}