using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    internal class DevTeamComparer : IComparer<DevTeam>
    {
        public int Compare(DevTeam x, DevTeam y)
        {
            return x.Task.Count.CompareTo(y.Task.Count);
        }
    }
}
