using Intuition.Domains.References;

namespace Intuition.Domains
{
    public class Error
    {
        /// <summary>
        ///  Gets or sets code number of error.
        /// </summary>
        public short Code { get; set; }

        /// <summary>
        ///  Gets or sets an instance of related <see cref="Reference.Language"/> class.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        ///  Gets or sets a unique identifier of related <see cref="Reference.Language"/> class.
        /// </summary>
        public string LanguageId { get; set; }

        /// <summary>
        /// Gets or sets short description of the message..
        /// </summary>
        public string Message { get; set; }

        public short HttpStatusCode { get; set; }
    }
}
