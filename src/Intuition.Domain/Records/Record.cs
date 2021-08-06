using System;

namespace Intuition.Domains.Records
{
    public class Record
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        
        public AppUser AppUser { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Data { get; set; }
    }
}
