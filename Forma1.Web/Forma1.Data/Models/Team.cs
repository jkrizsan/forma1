using System.ComponentModel.DataAnnotations;

namespace Forma1.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Display(Name = ("Name"))]
        public string Name { get; set; }
        
        [Display(Name = ("Year of Foundation"))]
        public int YearOfFoundation { get; set; }
        
        [Display(Name = ("Number Of Won World Championship"))]
        public int NumberOfWonWorldChampionship { get; set; }

        [Display(Name = ("Entry Fee is already paid"))]
        public bool PaidEntryFee { get; set; }

        public Team()
        {}

        public Team(string name, int yearOfFoundation, int numberOfWonWorldChampionship, bool paidEntryFee)
        {
            Name = name;
            YearOfFoundation = yearOfFoundation;
            NumberOfWonWorldChampionship = numberOfWonWorldChampionship;
            PaidEntryFee = paidEntryFee;
        }

    }
}
