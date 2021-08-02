using Google.Apis.Auth;
using Google.Auth;
using Intuition.Domains;
using Intuition.External.Google.Auth.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGoogleService _googleService;
        
        public AuthService(IGoogleService googleService)
        {
            _googleService = googleService ??
                throw new ArgumentNullException(nameof(googleService));
        }
    }
}
