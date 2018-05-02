using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Uptime {
    class Program {
        static void Main(string[] args) {

            // Get system hostname
            string hostname = System.Environment.MachineName;

            // Get system uptime
            PerformanceCounter upTime = new PerformanceCounter("System", "System Up Time");
            upTime.NextValue(); // get value one time to avoid zero on load
            string fmt = "0#"; // number format
            TimeSpan ts = TimeSpan.FromSeconds(upTime.NextValue());
            string sUptime = ts.Days + "d " + ts.Hours.ToString(fmt)
                + ":" + ts.Minutes.ToString(fmt)
                + ":" + ts.Seconds.ToString(fmt);

            Console.WriteLine(hostname + " is up for " + sUptime);

        }
    }
}
