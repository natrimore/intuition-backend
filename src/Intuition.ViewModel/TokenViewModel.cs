using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.ViewModels
{
    public class TokenViewModel
    {
        // [JsonProperty("login")]
        public string Login { get; set; }

        // [JsonProperty("auth_token")]
        public string AuthToken { get; set; }

        // [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        public string RefreshToken { get; set; }
    }
}
