using Laba1.Model; 
using System.Collections.Generic; 

namespace Laba1.Service
{
    public class EditionCompare : IComparer<Edition>
    {
        public int Compare(Edition edition1, Edition edition2)
            => edition1.EditionCount.CompareTo(edition2.EditionCount);
    }
}
