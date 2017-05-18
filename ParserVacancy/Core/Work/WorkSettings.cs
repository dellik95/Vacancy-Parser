using ParserVacancy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserVacancy.Work
{
    class WorkSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://rabota.ua/jobsearch/vacancy_list?regionId=1&keyWords=";
        public string SearchVac { get; set; } = "";
        public string Prefix { get; set; } = "&pg={currentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
