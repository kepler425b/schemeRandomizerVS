using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace schemeRandomizerVS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> targets = new List<string> { "Plain Text", "Comment" };
            List<string> targetStack = new List<string> { };

            int iter = 0;
            XDocument doc = XDocument.Load("asd.vssettings");
            foreach(XElement xe in doc.Descendants("Items").Elements())
            {
                targetStack.Insert(iter, xe.Attribute("Name").Value);
                iter++;
            }
            var random = new Random();
            int count = doc.Descendants("item").Count();
            for (int i = 0; i < targetStack.Count(); i++)
            {
                
                var color = String.Format("#{0:X6}", random.Next(0x10000000));
                var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == targetStack[i]).Single();
                element.Attribute("Foreground").Value = color;

            }
            doc.Save("altered.vssettings");
        }
    }
}
