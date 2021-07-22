using System;

namespace Intuition.Domains
{
    public class RefreshToken
    {
        /// <summary>
        ///  Gets or sets unique identifier.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets or sets refresh token of user
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// Gets or sets expiration time of refresh token
        /// </summary>
        public DateTime Expires { get; set; }
        
        /// <summary>
        /// Gets or sets created time of refresh token
        /// </summary>
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Gets or sets ip of user
        /// </summary>
        public string CreatedByIp { get; set; }
        
        /// <summary>
        ///  Gets or sets unique identifier of user id.
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        ///  Gets or sets an instance of <see cref="Domain.AppUser"/> class.
        /// </summary>
        public AppUser AppUser { get; set; }
    }
}
