using Intuition.Domains.Base;

namespace Intuition.Domains
{
    public class UserStatus : ReferenceEntityBase<short>
    {
        /// <summary>
        ///  Gets or sets short description of the status.
        /// </summary>
        public string Description { get; set; }
    }
}
