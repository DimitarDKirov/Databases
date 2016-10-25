//4.Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.

using System.Xml;

namespace DomDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..//..//catalog.xml";
            var document = new XmlDocument();
            document.Load(filePath);
            string xPath = "/catalog/album[price>20]";
            var catalogRoot = document.DocumentElement;

            XmlNodeList albums = catalogRoot.SelectNodes(xPath);
            foreach (XmlNode element in albums)
            {
                catalogRoot.RemoveChild(element);
            }

            document.Save("..//..//updateCatalog.xml");
        }
    }
}
