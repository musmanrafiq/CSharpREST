using CSharpREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
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

        public async Task<(List<RssFeedModel>, Error)> GetaAsync(string url)
        {
            try
            {
                var readerr = XmlReader.Create(url);
                var feed = SyndicationFeed.Load(readerr);


                var RSSFeedData = (from x in feed.Items
                                   select new RssFeedModel
                                   {
                                       Title = ((string)x.Title.Text),
                                       Link = (x.Links.FirstOrDefault().Title),

                                       PublishDate = ((string)x.PublishDate.ToString())
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
