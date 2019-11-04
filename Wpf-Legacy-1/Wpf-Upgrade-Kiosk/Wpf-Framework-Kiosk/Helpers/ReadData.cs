using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Framework_Kiosk.Helpers
{
    public static class ReadData
    {
        public static string Products()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Wpf_Framework_Kiosk.Data.Products.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
