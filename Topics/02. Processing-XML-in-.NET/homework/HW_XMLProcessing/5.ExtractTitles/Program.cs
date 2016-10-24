//5.Write a program, which using XmlReader extracts all song titles from catalog.xml.

using System;
using System.Collections.Generic;
using System.Xml;

namespace ExtractTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..//..//catalog.xml";
            IList<string> songs = new List<string>();
            using (var reader = XmlReader.Create(filePath))
            {
                while (reader.Read())
                {
                    if (reader.Name != "song" || reader.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    reader.ReadToDescendant("title");
                    string songName = reader.ReadElementContentAsString();
                    songs.Add(songName);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, songs));
        }
    }
}
