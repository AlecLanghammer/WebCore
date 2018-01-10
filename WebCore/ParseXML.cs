using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace WebCore
{
    public class ParseXML
    {
        string configPath = Directory.GetCurrentDirectory() + @"\config.xml";

        public void ReadConfigFile()
        {
            XElement config = XElement.Load(configPath);
            IEnumerable<XElement> settings = config.Elements();
        }
    }
}
