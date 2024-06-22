using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URL_Shortner_Task.Model;

[Table("url")]
public class Url
{
    [Key] public Guid Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortUrl { get; set; }

    public bool Clicked { get; set; }
}