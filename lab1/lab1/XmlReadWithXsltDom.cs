using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace lab1
{
    public static class XmlReadWithXsltDom
    {
        internal static void Read(string filepath)
        {
            var document = new XPathDocument(filepath);
            var navigator = document.CreateNavigator();
            var manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("x", "http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danych-v1.0");

            var query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@postac='Krem' and @nazwaPowszechnieStosowana='Mometasoni furoas']");
            query.SetContext(manager);
            var count = navigator.Select(query).Count;

            query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy");
            query.SetContext(manager);
            var productIterator = navigator.Select(query);

            var commonNameForms = new Dictionary<string, HashSet<string>>();
            var entityCreamCount = new Dictionary<string, int>();
            var entityTabletCount = new Dictionary<string, int>();

            while (productIterator.MoveNext())
            {
                var productIteratorCopy = productIterator.Current!.Clone();
                var attributesIterator = productIteratorCopy.Select("@*");

                var form = string.Empty;
                var commonName = string.Empty;
                var entity = string.Empty;
                while (attributesIterator.MoveNext())
                {
                    switch (attributesIterator.Current!.Name)
                    {
                        case "postac":
                            form = attributesIterator.Current.Value;
                            break;
                        case "nazwaPowszechnieStosowana":
                            commonName = attributesIterator.Current.Value;
                            break;
                        case "podmiotOdpowiedzialny":
                            entity = attributesIterator.Current.Value;
                            break;
                    }
                }

                if (commonNameForms.ContainsKey(commonName))
                    commonNameForms[commonName].Add(form);
                else
                    commonNameForms[commonName] = new HashSet<string> { form };

                if (form == "Krem")
                {
                    if (entityCreamCount.ContainsKey(entity))
                        entityCreamCount[entity]++;
                    else
                        entityCreamCount[entity] = 1;
                }
                else if (form.Contains("Tabletki"))
                {
                    if (entityTabletCount.ContainsKey(entity))
                        entityTabletCount[entity]++;
                    else
                        entityTabletCount[entity] = 1;
                }
            }

            var mostCreamsEntity = entityCreamCount.Aggregate((left, right) => left.Value > right.Value ? left : right).Key;
            var mostTabletsEntity = entityTabletCount.Aggregate((left, right) => left.Value > right.Value ? left : right).Key;
            var topThreeCreamEntities = (from ele in entityCreamCount orderby ele.Value descending select ele).Take(3);

            Console.WriteLine($"Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas: {count}");
            Console.WriteLine($"Liczba preparatów leczniczych o takiej samie nazwie powszechnej, pod różnymi postaciami: {commonNameForms.Values.Count(set => set.Count > 1)}");
            Console.WriteLine($"Podmiot produkujacy najwiecej kremow: {mostCreamsEntity}, podmiot produkujacy najwiecej tabletek: {mostTabletsEntity}");
            Console.WriteLine($"3 podmioty produkujace najwiecej kremu: ");
            foreach (var (entity, creamCount) in topThreeCreamEntities)
                Console.WriteLine($"\t{entity}: {creamCount}");
        }
    }
}