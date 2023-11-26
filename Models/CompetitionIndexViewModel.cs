namespace lan_week.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class CompetitionIndexViewModel
{
    public IEnumerable<Competition> UpcomingCompetitions { get; set; }
    public IEnumerable<Competition> PastCompetitions { get; set; }
}