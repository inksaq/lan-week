namespace lan_week.Models;
using System.ComponentModel.DataAnnotations;
public class NewsArticleViewModel
{
    [Required]
    [Display(Name = "Title")]
    public string? Title { get; set; }

    [Required]
    [Display(Name = "Content")]
    public string? Content { get; set; }

}
