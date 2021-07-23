using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Test.Task.Entities;

namespace Test.Task
{
    class ComparerForContains : IEqualityComparer<MacBase>
    {
        public bool Equals(MacBase x, MacBase y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Model == y.Model && x.Vendor == y.Vendor && x.Hw == y.Hw;
        }

        public int GetHashCode([DisallowNull] MacBase obj)
        {
            return 0;
        }
    }

}
