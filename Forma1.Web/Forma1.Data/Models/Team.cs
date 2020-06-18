using System;
using System.Collections.Generic;
using System.Text;

namespace Forma1.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfFoundation { get; set; }
        public int NumberOfWonWorldChampionship { get; set; }
        public bool PaidEntryFee { get; set; }
    }
}
