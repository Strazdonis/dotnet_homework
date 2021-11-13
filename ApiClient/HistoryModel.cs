namespace ApiClient
{
    public class HistoryModel
    {
        public string time_period_start { get; set; }
        public string time_period_end { get; set; }
        public string time_open { get; set; }
        public string time_close { get; set; }
        public string rate_open { get; set; }
        public string rate_high { get; set; }
        public string rate_low { get; set; }
        public string rate_close { get; set; }

        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null);  }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null);  }
        }
    }
}