namespace blazor
{
    public class ApiAuthSession
    {
        private readonly IHttpClientFactory _factory;
        public string? Token { get; private set; }

        public ApiAuthSession(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public void SetToken(string jwt)
        {
            Token = jwt;
            Console.WriteLine($"[ApiAuthSession] Token seteado: {jwt}");

            var http = _factory.CreateClient("WebApi");
            http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
        }


        public void Clear()
        {
            Console.WriteLine("[ApiAuthSession] Token eliminado.");
            Token = null;
            var http = _factory.CreateClient("WebApi");
            http.DefaultRequestHeaders.Authorization = null;
        }

    }
}
