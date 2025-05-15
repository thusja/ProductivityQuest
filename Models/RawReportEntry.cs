using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityQuest.Models
{
    public class RawReportEntry
    {
        public DateTime timestamp { get; set; }
        public int level { get; set; }
        public int exp { get; set; }
        public List<RawAppInfo> apps { get; set; }
    }

    public class RawAppInfo
    {
        public string name { get; set; }
        public string usage { get; set; }
        public string goal { get; set; }
        public string status { get; set; }
        public bool penalty { get; set; }
    }
}
