namespace lan_week.Models;
using System.ComponentModel.DataAnnotations;

public class CreateCompetitionViewModel
{
    [Required]
    [Display(Name = "Competition Name")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Event Date")]
    public DateTime EventDate { get; set; }

    [Required]
    [Display(Name = "Location")]
    public string Location { get; set; }

    [Required]
    [Display(Name = "Game Type")]
    public string GameType { get; set; }

    [Display(Name = "Prize Pool")]
    public decimal PrizePool { get; set; }

    [Required]
    [Display(Name = "Description")]
    public string Description { get; set; }
}
