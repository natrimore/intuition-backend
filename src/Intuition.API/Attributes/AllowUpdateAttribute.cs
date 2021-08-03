using System;

namespace Intuition.API.Attributes
{
    public class AllowUpdateAttribute : Attribute
    {
        public bool Updatable { get; set; } = true;
    }
}
