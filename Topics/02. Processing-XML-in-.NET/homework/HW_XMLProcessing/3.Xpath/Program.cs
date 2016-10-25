//3.Implement the previous using XPath.

using System;
using System.Collections.Generic;
using System.Xml;

namespace Xpath
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..//..//catalog.xml";
            var document = new XmlDocument();
            document.Load(filePath);
            string xPath = "/catalog/album/artist";

            XmlNodeList artists = document.SelectNodes(xPath);
            IDictionary<string, int> albumsNumber = new Dictionary<string, int>();
            foreach (XmlNode element in artists)
            {
                string artist = element.InnerText;
                if (!albumsNumber.ContainsKey(artist))
                {
                    albumsNumber.Add(artist, 1);
                }
                else
                {
                    albumsNumber[artist]++;
                }
            }

            foreach (var artistAlbums in albumsNumber)
            {
                Console.WriteLine($"Artist {artistAlbums.Key} has {artistAlbums.Value} albums");
            }
        }
    }
}
