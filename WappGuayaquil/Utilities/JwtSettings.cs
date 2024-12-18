namespace WappGuayaquil.Utilities
{
    public class JwtSettings
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Key { get; set; }

        public JwtSettings()
        {
            Issuer = "http://localhost:62188";
            Audience = "http://localhost:62188";
            Key = "8B373343-F538-430E-B827-3F4731E2C638";
        }

    }

}
