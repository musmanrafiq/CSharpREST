using CSharpREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpREST
{
    public class RssFeed
    {
        public async Task<(List<RssFeedModel>, Error)> GetAsync(string url)
        {
            try
            {
                using HttpClient _httpClient = new HttpClient();
                var rssString = await _httpClient.GetStringAsync(url);
                var xml = XDocument.Parse(rssString);
                var RSSFeedData = (from x in xml.Descendants("item")
                                   select new RssFeedModel
                                   {
                                       Title = ((string)x.Element("title")),
                                       Link = ((string)x.Element("link")),
                                       Description = ((string)x.Element("description")),
                                       PublishDate = ((string)x.Element("pubDate"))
                                   }).ToList();


                return (RSSFeedData, null);
            }
            catch (Exception exp)
            {
                return (null, new Error { Message = exp.Message });
            }
        }
    }
}
