using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;

namespace Console48
{
    static class ServiceControllerExtension
    {
        public static string GetImagePath(this ServiceController service)
        {
            return Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\" + service.ServiceName, "ImagePath", string.Empty).ToString(10000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var services = System.ServiceProcess.ServiceController.GetServices().Take(100);
            foreach (var service in services)
            {
                Console.WriteLine(service.ServiceName + ": " + service.GetImagePath());
            }
        }
    }
}
