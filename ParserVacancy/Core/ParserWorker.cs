using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserVacancy.Core
{
    class ParserWorker<T> where T:class
    {
        IParser<T> Parser;
        IParserSettings ParserSettings;

        HtmlLoader HtmlLoader;

        bool IsActive = false;
        public ParserWorker(IParser<T>parser)
        {
            Parser1 = parser;
        }
        public ParserWorker(IParser<T> parser,IParserSettings settings):this(parser)
        {
            ParserSettings1 = settings;
        }

        internal IParser<T> Parser1 { get => Parser; set => Parser = value; }
        internal IParserSettings ParserSettings1 { get => ParserSettings; set{ ParserSettings = value; HtmlLoader = new HtmlLoader(value); } }

        public event Action<object, T> OnNewData;
        public event Action<object> OnComplete;

        public void Start()
        {
            IsActive = true;
             Worker();
        }

        public void Abort()
        {
            
            IsActive = false;
        }

        public async  void Worker()
        {
            for (int i = ParserSettings1.StartPoint; i < ParserSettings1.EndPoint; i++)
            {
                if (!IsActive)
                {
                    OnComplete?.Invoke(this);
                    return;
                }

                var source = await HtmlLoader.GetSourceByPageId(i);

                var domParser =new HtmlParser();

                var document = await domParser.ParseAsync(source);



              var result=  Parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }
            OnComplete?.Invoke(this);
            IsActive = false;
        }
    }
}
