using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Tests.TokenManagement
{
    class HRCTokenManager
    {
        private static string _token;

        // Token'ı alıp saklama
        public static string GetToken()
        {
            if (string.IsNullOrEmpty(_token) || IsTokenExpired())
            {
                RefreshToken();
            }
            return _token;
        }

        // Token'ı yenileme
        private static void RefreshToken()
        {
            // Burada, API'nize bir login isteği gönderip yeni bir token alabilirsiniz.
            // Örneğin, hazır bir token varsa burada direkt kullanabiliriz.

            // Örnek: API'den token almak için HTTP isteği
            var client = new HttpClient();
            var response = client.PostAsJsonAsync("https://test-hrcenter.azurewebsites.net/tr/login", new { Username = "oliver.q2424@gmail.com", Password = "Neyasis123." }).Result;

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = response.Content.ReadFromJsonAsync<TokenResponse>().Result;
                _token = tokenResponse.Token;  // Token'ı sakla
            }
            else
            {
                throw new Exception("Token alımı başarısız oldu");
            }
        }

        // Token'ın geçerliliğini kontrol etme (örneğin, süresi dolmuşsa)
        private static bool IsTokenExpired()
        {
            // Eğer token süresi dolmuşsa veya null ise yenileme işlemi yapın
            // Burada token'ın expiration time'ını kontrol edebilirsiniz
            // Bu örnekte basitçe token'ın null olup olmadığını kontrol ediyoruz.
            return string.IsNullOrEmpty(_token);
        }
    }
    public class TokenResponse
    {
        public string Token { get; set; }
    }
}
