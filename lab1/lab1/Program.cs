using System;
using System.IO;

namespace lab1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var xmlpath = Path.Combine("Assets", "data.xml");
            // DOM
            Console.WriteLine("XML loaded by DOM Approach");
            XmlReadWithXsltDom.Read(xmlpath);

            // SAX
            Console.WriteLine("\nXML loaded by SAX Approach");
            XmlReadWithSax.Read(xmlpath);

            // XPath 
            Console.WriteLine("\nXML loaded with XPath");
            XmlReadWithXsltDom.Read(xmlpath);

            // Deeper analysis
            Console.WriteLine("\nDeeper analysis");
            DeeperAnalysis.ReadActiveIngredientStats(xmlpath);
            DeeperAnalysis.PackingOptionsAnalysis(xmlpath);
        }
    }
}