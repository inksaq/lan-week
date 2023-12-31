namespace lan_week.Models;
using System.ComponentModel.DataAnnotations;
public class CompetitionViewModel
{
    [Key]
    public int CompetitionId { get; set; }

    [Required]
    [Display(Name = "Competition Name")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Competition Date")]
    public DateTime EventDate { get; set; }

    [Required]
    [Display(Name = "Location")]
    public string Location { get; set; }

    [Display(Name = "Maximum Teams")]
    public int MaxTeams { get; set; }

    [Display(Name = "Prize Pool")]
    public decimal PrizePool { get; set; }

    [Display(Name = "Description")]
    public string Description { get; set; }

}
