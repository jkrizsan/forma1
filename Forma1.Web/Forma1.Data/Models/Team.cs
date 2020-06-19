using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forma1.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Display(Name = ("Name"))]
        public string Name { get; set; }
        [Display(Name = ("Foundation Year"))]
        public int YearOfFoundation { get; set; }
        [Display(Name = ("Number Of Won World Championship"))]
        public int NumberOfWonWorldChampionship { get; set; }
        [Display(Name = ("Paid Entry Fee"))]
        public bool PaidEntryFee { get; set; }
    }
}
