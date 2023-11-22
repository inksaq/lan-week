using System.ComponentModel.DataAnnotations;

public class NewsArticle
{

    [Key]
    public int ArticleId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime PublishedDate { get; set; }

    public string? AuthorId { get;set; }
}