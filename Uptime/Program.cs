using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Uptime {
    class Program {
        static void Main(string[] args) {

            if(args.Length == 0) {
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
            } else {
                if (args[0] == "--version") {
                    string maj_ver = "0";
                    string min_ver = "1";
                    string build = "007";
                    string build_date = "2018.06.01";

                    Console.WriteLine("Uptime version {0}.{1} build {2} of {3}", maj_ver, min_ver, build, build_date);
                    Console.WriteLine("By phsouto : https://github.com/phsouto");
                }
            }
        }
    }
}
