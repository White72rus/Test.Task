using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Test.Task.Entities;

namespace Test.Task
{
    class MacComparerForThreeOctet : IEqualityComparer<MacBase>
    {
        public bool Equals(MacBase x, MacBase y)
        {
            //x.TerminalMAC = x.TerminalMAC.Trim().ToUpper();
            //y.TerminalMAC = y.TerminalMAC.Trim().ToUpper();

            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.TerminalMAC.Substring(0, 6).Equals(y.TerminalMAC.Substring(0, 6));
        }

        public int GetHashCode([DisallowNull] MacBase obj)
        {
            return 0;
        }
    }

}
