using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.ViewModels
{
    public class RecordDetailsViewModel
    {
        public DateTime Date { get; set; }
        public int TotalAttempts { get; set; }
        public int CorrectAnswers { get; set; }
    }
}
