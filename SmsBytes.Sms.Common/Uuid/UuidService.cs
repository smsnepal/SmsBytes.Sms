namespace SmsBytes.Sms.Common.Uuid
{
    public class UuidService : IUuidService
    {
        private string GenerateUuId()
        {
            return System.Guid.NewGuid().ToString();
        }

        public string GenerateUuId(string prefix)
        {
            return $"{prefix}_{GenerateUuId()}";
        }
    }
}
