namespace Intuition.ViewModels
{
    public class AppTimeZoneViewModel
    {
        /// <summary>
        ///  Gets or sets the time zone identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///  Gets or sets the general display name that represents the time zone.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///  Gets or sets the display name for the time zone's standard time.
        /// </summary>
        public string StandartName { get; set; }

        /// <summary>
        ///  Gets or sets the hours component of the time interval.
        /// </summary>
        public int BaseUtcOffsetHours { get; set; }

        /// <summary>
        ///  Gets or sets the minutes component of the time interval.
        /// </summary>
        public int BaseUtcOffsetMinutes { get; set; }

        /// <summary>
        ///  Gets or sets the seconds component of the time interval.
        /// </summary>
        public int BaseUtcOffsetSeconds { get; set; }
    }
}
