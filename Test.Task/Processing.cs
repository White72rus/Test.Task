using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Test.Task.Entities;

namespace Test.Task
{
    public class Processing
    {
        private HashSet<MacBase> outList = new HashSet<MacBase>();
        public async void Run()
        {
            CultureInfo turkish = new CultureInfo("en-US");

            Console.WriteLine("Processing...");

            IList<MacBase> inList = new List<MacBase>();
            List<MacBase> completList = new List<MacBase>();

            DataLayer data = new DataLayer();

            inList = await data.GetDataAsync();

            MacComparerForThreeOctet comparerForThreeOctet = new MacComparerForThreeOctet();
            MacComparerForTwoOctet comparerForTwoOctet = new MacComparerForTwoOctet();
            ComparerForContains comparerForContains = new ComparerForContains();

            for (int i = 0; i < inList.Count; i++)
            {
                Logger.ShowProgress(i, inList.Count);

                MacBase item = inList[i];

                var tempList = inList.Where(o => o.Model == item.Model && o.Vendor == item.Vendor && o.Hw == item.Hw).ToHashSet();

                if (outList.Contains(tempList.FirstOrDefault(), comparerForContains))
                    continue;

                if (tempList.Count < 2)
                    continue;

                // Удоляем дубли
                tempList = tempList.Distinct(comparerForThreeOctet).ToHashSet();
                tempList = tempList.Distinct(comparerForTwoOctet).ToHashSet();

                Worker(tempList);

                // Раскоментить для лога в консоль. 
                //foreach (var item2 in outList)
                //{
                //    Logger.Log($"{item2.TerminalMAC}; {item2.Vendor}; {item2.Model}; {item2.Hw}");
                //}
            }
        }

        /// <summary>
        /// Метод обработки строк МАС адресов.
        /// </summary>
        /// <param name="list"></param>
        private void Worker(HashSet<MacBase> list)
        {
            if (list.Count == 0)
                return;

            HashSet<MacBase> innerList = list;

            MacBase elem = innerList.FirstOrDefault();

            if (!Help.MacAdrrValidator(elem.TerminalMAC))
                return;

            string firstThreeOctet = elem.TerminalMAC.Substring(0, 6).ToUpper();
            string firstTwoOctet = elem.TerminalMAC.Substring(0, 4).ToUpper();

            foreach (var elem2 in innerList)
            {
                if (elem2.TerminalMAC.Contains(firstThreeOctet, StringComparison.InvariantCultureIgnoreCase))
                {
                    outList.Add(new MacBase
                    {
                        Id = elem.Id,
                        TerminalMAC = firstThreeOctet + "000000" + " - " + firstThreeOctet + "FFFFFF",
                        Vendor = elem.Vendor,
                        Model = elem.Model,
                        Hw = elem.Hw,
                    });
                    continue;
                }

                if (elem2.TerminalMAC.Contains(firstTwoOctet, StringComparison.InvariantCultureIgnoreCase))
                {
                    outList.Add(new MacBase
                    {
                        Id = elem.Id,
                        TerminalMAC = firstTwoOctet + "00000000" + " - " + firstTwoOctet + "FFFFFFFF",
                        Vendor = elem.Vendor,
                        Model = elem.Model,
                        Hw = elem.Hw,
                    });
                    continue;
                }
            }

            innerList.Remove(elem);

            Worker(innerList);

        }
    }
}
