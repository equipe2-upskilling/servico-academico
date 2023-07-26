namespace Academic.Domain
{
    public class AccessToken
    {
        public bool Authenticated { get; set; }
        public string Expiration { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
