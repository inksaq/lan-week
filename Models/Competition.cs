using System.ComponentModel.DataAnnotations;


public class Competition
{
    [Key]
    public int CompetitionId { get; set; }
    public string Name { get; set; }
    public DateTime EventDate { get; set; }

    public string Location {get; set; }
    public string GameType { get; set; }
    public decimal PrizePool { get; set; }
    public string Description { get; set; }
}