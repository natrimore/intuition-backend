using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.ViewModels
{
    public class RecordViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public AppUserViewModel AppUser { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Data { get; set; }
    }
}
