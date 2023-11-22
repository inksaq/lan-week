using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class LanCompetition
{

    [Key]
    public int LanEventId { get; set; }
    public string GameType { get; set; }
    public DateTime EventDate { get; set; }
    public decimal MoneyPot { get; set; }
    public string TeamLeaderId { get; set; } // User ID of the team leader

    // Navigation properties
    public IdentityUser TeamLeader { get; set; }
    public ICollection<TeamMember> TeamMembers { get; set; }



}