//2.Write program that extracts all different artists which are found in the catalog.xml.
//    For each author you should print the number of albums in the catalogue.
//    Use the DOM parser and a hash-table.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Artists
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..//..//catalog.xml";

            var document = new XmlDocument();
            document.Load(filePath);
            var catalogRoot = document.DocumentElement;

            IDictionary<string, int> albumsNumber = new Dictionary<string, int>();
            foreach (XmlElement element in catalogRoot.ChildNodes)
            {
                string artist = element["artist"].InnerText;
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
