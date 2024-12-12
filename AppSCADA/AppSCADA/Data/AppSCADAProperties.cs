using System;
using System.Collections.Generic;
using System.Text;

namespace AppSCADA
{
    public class AppSCADAProperties
    {
        public static SCADAAppConfiguration SCADAAppConfiguration { get; set; }
        public static int TrendLimitPoints{ get; set; }
        public AppSCADAProperties()
        {
            
        }
    }
}
