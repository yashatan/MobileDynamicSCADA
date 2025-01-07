using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSCADA
{
    public class MainFlyOutFlyoutMenuItem
    {
        public MainFlyOutFlyoutMenuItem()
        {
            TargetType = typeof(MainFlyOutFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}