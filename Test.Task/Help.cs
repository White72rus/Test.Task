using System.Collections.Generic;
using System.Text.RegularExpressions;
using Test.Task.Entities;

namespace Test.Task
{
    public static class Help
    {
        public static bool MacAdrrValidator(string value)
        {
            string pattern = "^([0-9A-Fa-f]{2}[0-9A-Fa-f]{2}[0-9A-Fa-f]{2}[0-9A-Fa-f]{2}[0-9A-Fa-f]{2}[0-9A-Fa-f]{2})$";
            var rxMac = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return rxMac.IsMatch(value);
        }

        private static bool Contains<T>(this IList<T> list, T value) where T : MacBase
        {
            foreach (var item in list)
            {
                return item.Model == value.Model && item.Vendor == value.Vendor && item.Hw == value.Hw;
            }
            return false;
        }
    }
}
