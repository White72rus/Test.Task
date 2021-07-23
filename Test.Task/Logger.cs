using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Task
{
    public static class Logger
    {
        public static void ShowProgress(int curent, int full)
        {
            double percents = ((double)(100 * curent) / full);     //Math.Round((double)(100 * i) / outList.Count);

            Console.CursorVisible = false;
            Console.CursorLeft = 0;
            Console.Write($"Progress...: {percents.ToString("0.000")}% [ {curent} of {full} ]");
        }

        public static void Log(string value)
        {
            Console.WriteLine(value);
        }
    }
}
