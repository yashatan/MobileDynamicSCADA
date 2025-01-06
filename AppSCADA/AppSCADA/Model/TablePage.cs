using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSCADA
{
    public class TablePage : BaseSCADAPage
    {
        public TablePage()
        {
            Tags = new List<TagInfo>();
            PageType = 1;
        }
        public List<TagInfo> Tags { get; set; }
    }
}
