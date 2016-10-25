//6.Rewrite the same using XDocument and LINQ query.

using System;
using System.Linq;
using System.Xml.Linq;

namespace XmlLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..//..//catalog.xml";
            XDocument document = XDocument.Load(filePath);
            var songs = document.Descendants("song")
                .Select(el => el.Element("title").Value);

            Console.WriteLine(string.Join(Environment.NewLine, songs));
        }
    }
}
