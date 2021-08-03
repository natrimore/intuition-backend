﻿namespace Intuition.ViewModels
{
    public class ErrorViewModel
    {
        /// <summary>
        ///  Gets or sets code of error.
        /// </summary>
        public short Code { get; set; }

        /// <summary>
        ///  Gets or sets laguageId.
        /// </summary>
        public string LanguageId { get; set; }

        /// <summary>
        /// Gets or sets error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///  Gets or sets http status code.
        /// </summary>
        public short HttpStatusCode { get; set; }
    }
}
