using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


public class TeamMember
{
 [Key]
    public int TeamMemberId { get; set; }
    public int LanEventId { get; set; }
    public string UserId { get; set; } 

    public LanCompetition LanCompetition { get; set; }
    public IdentityUser User { get; set; }
}
