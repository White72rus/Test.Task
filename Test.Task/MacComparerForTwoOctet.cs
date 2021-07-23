using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Test.Task.Entities;

namespace Test.Task
{
    class MacComparerForTwoOctet : IEqualityComparer<MacBase>
    {
        public bool Equals(MacBase x, MacBase y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.TerminalMAC.Substring(0, 4) == y.TerminalMAC.Substring(0, 4) && !x.TerminalMAC.Substring(4, 2).Equals(y.TerminalMAC.Substring(4, 2));
        }

        public int GetHashCode([DisallowNull] MacBase obj)
        {
            return 0;
        }
    }

}
