using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.Domains.Base
{
    public abstract class ReferenceEntityBase<TKey> : IEntity<TKey>
    {
        /// <summary>
        ///  Gets or sets unique identitier.
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        ///  Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Gets or sets display name.
        /// </summary>
        public string DisplayName { get; set; }
    }
}
