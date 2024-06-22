using System.Buffers.Text;
using System.Text;

namespace URL_Shortner_Task.Model;

public class RequestUrl
{
    public string OriginalUrl { get; set; }

    public Url ToUrl()
    {
        return new Url()
        {
            Id = Guid.NewGuid(),
            OriginalUrl = OriginalUrl,
            ShortUrl = Convert.ToBase64String(Encoding.UTF8.GetBytes(OriginalUrl)).Substring(1, 7)
        };
    }
}