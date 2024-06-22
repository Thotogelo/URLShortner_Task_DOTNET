using Microsoft.AspNetCore.Mvc;
using URL_Shortner_Task.Data;
using URL_Shortner_Task.Model;

namespace URL_Shortner_Task.Controller;

[ApiController]
[Route("[controller]/")]
public class UrlController : ControllerBase
{
    private readonly DataContext _dataContext;

    public UrlController(DataContext dataContext)
        => _dataContext = dataContext;

    [HttpPost]
    public IActionResult SaveUrl([FromBody] RequestUrl? requestUrl)
    {
        if (requestUrl != null)
            return BadRequest();


        var existShortUrl = _dataContext.Urls.First(x => x.ShortUrl == requestUrl.OriginalUrl);

        if (existShortUrl != null)
        {
            _dataContext.Entry(existShortUrl).Entity.Clicked = true;
            _dataContext.SaveChanges();
            return Ok(existShortUrl.OriginalUrl);
        }

        var existLongUrl = _dataContext.Urls.First(x => x.OriginalUrl == requestUrl.OriginalUrl);

        if (existLongUrl != null)
        {
            return Ok(existLongUrl.ShortUrl);
        }

        _dataContext.Add(requestUrl.ToUrl());
        _dataContext.SaveChanges();
        return Created();
    }
}