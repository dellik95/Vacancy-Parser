using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParserVacancy.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string URI;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            URI = settings.BaseUrl + settings.SearchVac + settings.Prefix;
        }

        public bool statusCode { get; private set; }

        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUri = URI.Replace("{currentId}", id.ToString());
            string source=null;
            var response = await client.GetAsync(currentUri);
            if (response!=null && response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}

