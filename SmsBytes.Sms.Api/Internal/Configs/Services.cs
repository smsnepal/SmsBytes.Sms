namespace SmsBytes.Sms.Api.Internal.Configs
{
    public class Services
    {
        public KeyStoreConfig KeyStore { set; get; }
        public Gateway Gateway { set; get; }
    }

    public class Gateway
    {
        public string Url { set; get; }
    }

    public class KeyStoreConfig
    {
        public string Url { set; get; }
    }
}
